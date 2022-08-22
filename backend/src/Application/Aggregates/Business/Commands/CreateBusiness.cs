using Domain.Enums;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Domain.Utils;

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
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IBusinessRepository _businessRepository;
            private readonly IAddressRepository _addressRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IBusinessRepository businessRepository,
                           IAddressRepository addressRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _businessRepository = businessRepository;
                _addressRepository = addressRepository;
                _configuration = configuration;
                _mapper = mapper;
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
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
        }
    }
}