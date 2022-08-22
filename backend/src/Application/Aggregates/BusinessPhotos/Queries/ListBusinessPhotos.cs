using Application.Result;
using AutoMapper;
using Domain.DTO.Business;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.BusinessPhotos.Queries
{
    public class ListBusinessPhotos
    {
        public class Query : IRequest<StandardResult<List<ListBusinessDTO>>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<List<ListBusinessDTO>>>
        {
            private readonly IBusinessRepository _businessRepository;
            private readonly IMapper _mapper;

            public Handler(IBusinessRepository businessRepository,
                           IMapper mapper)
            {
                _businessRepository = businessRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<List<ListBusinessDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<List<ListBusinessDTO>> { };

                var businessList = await _businessRepository.ReadAll();

                var responseData = businessList.Select(x => _mapper.Map<Domain.Entities.Business, ListBusinessDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}