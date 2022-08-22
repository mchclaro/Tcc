using Application.Result;
using AutoMapper;
using Domain.DTO.Business;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Aggregates.Business.Queries
{
    public class DetailsBusiness
    {
        public class Query : IRequest<StandardResult<ListBusinessDTO>>
        {
            public int Id { get; set; }
        }
        public class CommandValidator : AbstractValidator<Query>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Query,StandardResult<ListBusinessDTO>>
        {
            private readonly IBusinessRepository _businessRepository;
            private readonly IMapper _mapper;

            public Handler(IBusinessRepository businessRepository,
                           IMapper mapper)
            {
                _businessRepository = businessRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<ListBusinessDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<ListBusinessDTO>();

                var business = await _businessRepository.Read(request.Id);

                if (business == null)
                {
                    result.AddError(Code.NotFound,"Nenhum comércio encontrado para o Id informado.");
                    return result.GetResult();
                }

                var dto = _mapper.Map<Domain.Entities.Business, ListBusinessDTO>(business);

                result.AddData(dto);

                return result.GetResult();
            }
        }
    }
}