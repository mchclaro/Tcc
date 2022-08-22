using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Product.Commands;
using AutoMapper;

namespace Application.Aggregates.Product.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProduct.Command, Domain.Entities.Product>(MemberList.Source);
            CreateMap<UpdateProduct.Command, Domain.Entities.Product>(MemberList.Source);

            CreateMap<DeleteProduct.Command, Domain.Entities.Product>(MemberList.Source);
        }
        
    }
}