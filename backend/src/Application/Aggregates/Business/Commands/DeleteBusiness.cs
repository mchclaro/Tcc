using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MediatR;

namespace Application.Aggregates.Business.Commands
{
    public class DeleteBusiness
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            
            private readonly IBusinessRepository _businessRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;
            private readonly IFileStorageServiceS3 _fileStorage;

            public Handler(IBusinessRepository businessRepository,
                           IFileStorageServiceS3 fileStorage,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _businessRepository = businessRepository;
                _fileStorage = fileStorage;
                _configuration = configuration;
                _mapper = mapper;
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                if (!await _businessRepository.Exists(request.Id))
                {
                    result.AddError(Code.BadRequest, "Comércio não encontrado.");
                    return result.GetResult();
                }
                
                var business = await _businessRepository.Read(request.Id);
                
                if(business.MainImage != null)
                {
                    await _fileStorage.DeleteFileFromUrlS3(business.MainImage);
                }
                
                await _businessRepository.Delete(request.Id);
                
                return result.GetResult();
            }
        }
    }
}