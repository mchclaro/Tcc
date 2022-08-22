using Application.Aggregates.BusinessPhotos.Commands;
using AutoMapper;
using Domain.DTO.Business;

namespace Application.Aggregates.BusinessPhotos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBusinessPhotos.Command, Domain.Entities.Business>(MemberList.Source);
            CreateMap<UpdateBusinessPhotos.Command, Domain.Entities.Business>(MemberList.Source);

            CreateMap<DeleteBusinessPhotos.Command, Domain.Entities.Business>(MemberList.Source);

            // CreateMap<Domain.Entities.BusinessPhotos, ListBusinessPhotosDTO>(MemberList.Destination)
            // //    .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.CNPJ, src => src.MapFrom(src => src.CNPJ))
            //    .ForMember(dest => dest.SocialReson, src => src.MapFrom(src => src.SocialReson))
            //    .ForMember(dest => dest.FantasyName, src => src.MapFrom(src => src.FantasyName))
            //    .ForMember(dest => dest.Priority, src => src.MapFrom(src => src.Priority))
            //    .ForMember(dest => dest.Category, src => src.MapFrom(src => src.Category))
            //    .ForMember(dest => dest.Address, src => src.MapFrom(src => new AddressDto
            //    {
            //        Street = src.Address.Street,
            //        StreetNumber = src.Address.StreetNumber,
            //        Complement = src.Address.Complement,
            //        District = src.Address.District,
            //        City = src.Address.City,
            //        State = src.Address.State,
            //        ZipCode = src.Address.ZipCode
            //    }));
        }
    }
}