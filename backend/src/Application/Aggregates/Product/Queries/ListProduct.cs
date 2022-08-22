using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.Product;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Product.Queries
{
    public class ListProduct
    {
        public class Query : IRequest<StandardResult<List<ListProductDTO>>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<List<ListProductDTO>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public Handler(IProductRepository productRepository,
                           IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<List<ListProductDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<List<ListProductDTO>> { };

                var productList = await _productRepository.ReadAll();

                var responseData = productList.Select(x => _mapper.Map<Domain.Entities.Product, ListProductDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}