using Domain.Enums;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Domain.Utils;
using Domain.Interfaces.Services;

namespace Application.Aggregates.Business.Commands
{
    public class CreateBusiness
    {
        public class Command : IRequest<StandardResult<object>>
        {
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
            private readonly IAddressRepository _addressRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;
            private readonly IFileStorageService _fileStorage;
            private readonly string _imageBucket;

            public Handler(IBusinessRepository businessRepository,
                           IAddressRepository addressRepository,
                           IConfiguration configuration,
                           IFileStorageService fileStorage,
                           IMapper mapper)
            {
                _fileStorage = fileStorage;
                _businessRepository = businessRepository;
                _addressRepository = addressRepository;
                _configuration = configuration;
                _mapper = mapper;
                _imageBucket = "adp-images";
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
                    if (request.CNPJ == null)
                    {
                        result.AddError(Code.BadRequest, "Não foi possível continuar o cadastro pois o CNPJ é inválidos.");
                        return result.GetResult();
                    }

                    if (await _businessRepository.IsCnpjInUse(request.CNPJ))
                    {
                        result.AddError(Code.BadRequest, "Já existe uma conta associada ao CNPJ informado.");
                        return result.GetResult();
                    }

                    request.CNPJ = ValidationHelper.RemoveDirtCharsForCnpj(request.CNPJ);

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

                    if (request.MainImage == null)
                    {
                        string invalidImage = "Foto não encontrada";
                        result.AddError(Code.BadRequest, invalidImage);
                        return result.GetResult();
                    }

                    (bool fileSizeExceeded, string mainImage) = await updateBusinessMainImage(request);

                    if (fileSizeExceeded)
                    {
                        result.AddError(Code.BadRequest, mainImage);
                        return result.GetResult();
                    }

                    var entity = _mapper.Map<Command, Domain.Entities.Business>(request);

                    if (!string.IsNullOrEmpty(mainImage))
                    entity.MainImage = mainImage;

                    entity.AddressId = await saveAddress(request);
                    
                    await _businessRepository.Create(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao cadastrar o comércio");
                }

                return result.GetResult();
            }

            private async Task<int> saveAddress(Command request)
            {
                var address = new Address
                {
                    Street = request.AddressStreet,
                    StreetNumber = request.AddressStreetNumber,
                    Complement = request.AddressComplement,
                    District = request.AddressDistrict,
                    ZipCode = ValidationHelper.RemoveDirtCharsForCep(request.Zipcode),
                    State = request.AddressState,
                    City = request.AddressCity
                };

                return await _addressRepository.Create(address);
            }

            private async Task<(bool, string)> updateBusinessMainImage(Command request)
            {
                string mainImage = string.Empty;
                bool fileSizeExceeded = false;

                if (request.MainImage is null)
                    return (fileSizeExceeded, mainImage);

                if (!FileSizeValidationHelper.IsFileSizeAllowed(_configuration, request.MainImage.Length))
                {
                    fileSizeExceeded = true;
                    mainImage = "O tamanho da foto excede o limite permitido. Selecione uma foto que possua no máximo 8MB de tamanho.";

                    return (fileSizeExceeded, mainImage);
                }

                string mainImageUuid = Guid.NewGuid().ToString("N");

                string objectName = $"business_photo_{mainImageUuid}{Path.GetExtension(request.MainImage.FileName)}";

                await _fileStorage.UploadFileFromHttpIFormFile(request.MainImage, _imageBucket, objectName);

                mainImage = _fileStorage.GetFileUrl(_imageBucket, objectName);

                return (fileSizeExceeded, mainImage);
            }

        }
    }
}