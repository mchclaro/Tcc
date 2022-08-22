using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MediatR;

namespace Application.Aggregates.BusinessPhotos.Commands
{
    public class UpdateBusinessPhotos
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
            public int AddressId { get; set; }
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IBusinessRepository _businessRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IBusinessRepository businessRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _businessRepository = businessRepository;
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