using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Product.Commands;
using AutoMapper;
using Domain.DTO.Product;

namespace Application.Aggregates.Product.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProduct.Command, Domain.Entities.Product>(MemberList.Source);
            CreateMap<UpdateProduct.Command, Domain.Entities.Product>(MemberList.Source);

            CreateMap<DeleteProduct.Command, Domain.Entities.Product>(MemberList.Source);

            CreateMap<Domain.Entities.Product, ListProductDTO>(MemberList.Destination)
               .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
               .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
               .ForMember(dest => dest.BusinessId, src => src.MapFrom(src => src.BusinessId));
        }
        
    }
}