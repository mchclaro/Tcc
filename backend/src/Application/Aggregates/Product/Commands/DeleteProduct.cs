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
    public class DeleteProduct
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public int Id { get; set; }
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

                if (!await _productRepository.Exists(request.Id))
                {
                    result.AddError(Code.BadRequest, "Produto não encontrado.");
                    return result.GetResult();
                }

                await _productRepository.Delete(request.Id);
                return result.GetResult();
            }
        }
    }
}