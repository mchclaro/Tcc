using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Enums;
using Domain.Filters;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Utils;
using MediatR;

namespace Application.Aggregates.Business.Commands
{
    public class UpdateBusiness
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public int Id { get; set; }
            public string CNPJ { get; set; }
            public string SocialReson { get; set; }
            public string FantasyName { get; set; }
            public string BusinessName { get; set; }
            public Priority Priority { get; set; }
            public Category Category { get; set; }
            public string Zipcode { get; set; }
            public string AddressStreet { get; set; }
            public string AddressStreetNumber { get; set; }
            public string AddressDistrict { get; set; }
            public string AddressState { get; set; }
            public string AddressComplement { get; set; }
            public string AddressCity { get; set; }
            public IFormFile MainImage { get; set; }
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IBusinessRepository _businessRepository;
            private readonly IConfiguration _configuration;
            private readonly IFileStorageService _fileStorage;
            private readonly IMapper _mapper;
            private readonly string _imageBucket;

            public Handler(IBusinessRepository businessRepository,
                           IFileStorageService fileStorage,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _fileStorage = fileStorage;
                _businessRepository = businessRepository;
                _configuration = configuration;
                _mapper = mapper;
                _imageBucket = "adp-images";
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };
                string mainImage = "";
                try
                {
                    var business = await _businessRepository.Read(new BusinessFilter { Id = request.Id });

                    if (business is null)
                    {
                        result.AddError(Code.NotFound, "Comércio não encontrado!");
                        return result.GetResult();
                    }

                    if (string.IsNullOrEmpty(request.SocialReson))
                    {
                        result.AddError(Code.BadRequest, "O razão social não pode ser vazia.");
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.FantasyName))
                    {
                        result.AddError(Code.BadRequest, "O nome fantasia não pode ser vazio.");
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.BusinessName))
                    {
                        result.AddError(Code.BadRequest, "O nome do comércio não pode ser vazio.");
                        return result.GetResult();
                    }

                    var entity = _mapper.Map<Command, Domain.Entities.Business>(request);

                    //faz o upload da foto principal do comércio
                    if (request.MainImage != null)
                    {
                        string photoUuid = Guid.NewGuid().ToString("N");
                        string objectName = $"business_photo_{photoUuid}{Path.GetExtension(request.MainImage.FileName)}";
                        await _fileStorage.UploadFileFromHttpIFormFile(request.MainImage, _imageBucket, objectName);
                        mainImage = _fileStorage.GetFileUrl(_imageBucket, objectName);

                        if (!string.IsNullOrEmpty(entity.MainImage) && entity.MainImage != mainImage)
                        {
                            await _fileStorage.DeleteFileFromUrl(entity.MainImage);
                        }
                    }

                    if (!string.IsNullOrEmpty(mainImage))
                        entity.MainImage = mainImage;

                    await _businessRepository.Update(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao atualizar o comércio");
                }

                return result.GetResult();
            }
        }
    }
}