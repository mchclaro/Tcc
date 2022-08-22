using Application.Result;
using AutoMapper;
using Domain.DTO.Business;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Business.Queries
{
    public class ListBusiness
    {
        public class Query : IRequest<StandardResult<object>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<object>>
        {
            private readonly IBusinessRepository _businessRepository;
            private readonly IMapper _mapper;

            public Handler(IBusinessRepository businessRepository,
                           IMapper mapper)
            {
                _businessRepository = businessRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<object>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                var businessList = await _businessRepository.ReadAll();

                var responseData = businessList.Select(x => _mapper.Map<Domain.Entities.Business, ListBusinessDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}