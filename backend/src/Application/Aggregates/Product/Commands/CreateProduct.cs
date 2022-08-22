using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Product.Commands
{
    public class CreateProduct
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int BusinessId { get; set; }
        }

        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IProductRepository productRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _productRepository = productRepository;
                _configuration = configuration;
                _mapper = mapper;
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
                    if (string.IsNullOrEmpty(request.Name))
                    {
                        result.AddError(Code.BadRequest, "O nome não pode ser vazia.");
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.Description))
                    {
                        result.AddError(Code.BadRequest, "O descrição não pode ser vazia.");
                        return result.GetResult();
                    }
                                    
                    var entity = _mapper.Map<Command, Domain.Entities.Product>(request);

                    await _productRepository.Create(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao cadastrar o produto");
                }

                return result.GetResult();
            }
        }
    }
}