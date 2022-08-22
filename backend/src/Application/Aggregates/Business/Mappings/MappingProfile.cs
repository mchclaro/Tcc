using Application.Aggregates.Business.Commands;
using AutoMapper;
using Domain.DTO.Business;
using Domain.Entities;
using Domain.Utils;

namespace Application.Aggregates.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBusiness.Command, Domain.Entities.Business>(MemberList.Source);
            CreateMap<UpdateBusiness.Command, Domain.Entities.Business>(MemberList.Source)
            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
            .ForMember(dest => dest.CNPJ, src => src.MapFrom(src => src.CNPJ))
            .ForMember(dest => dest.SocialReson, src => src.MapFrom(src => src.SocialReson))
            .ForMember(dest => dest.FantasyName, src => src.MapFrom(src => src.FantasyName))
            .ForMember(dest => dest.BusinessName, src => src.MapFrom(src => src.BusinessName))
            .ForMember(dest => dest.Priority, src => src.MapFrom(src => src.Priority))
            .ForMember(dest => dest.Category, src => src.MapFrom(src => src.Category))
            .ForMember(dest => dest.Address, src => src.MapFrom(src => new Address
            {
                Street = src.AddressStreet,
                StreetNumber = src.AddressStreetNumber,
                District = src.AddressDistrict,
                City = src.AddressCity,
                State = src.AddressState,
                Complement = src.AddressComplement,
                ZipCode = ValidationHelper.RemoveDirtCharsForCep(src.Zipcode)
            }));

            CreateMap<DeleteBusiness.Command, Domain.Entities.Business>(MemberList.Source);

            CreateMap<Domain.Entities.Business, ListBusinessDTO>(MemberList.Destination)
               .ForMember(dest => dest.CNPJ, src => src.MapFrom(src => src.CNPJ))
               .ForMember(dest => dest.SocialReson, src => src.MapFrom(src => src.SocialReson))
               .ForMember(dest => dest.FantasyName, src => src.MapFrom(src => src.FantasyName))
               .ForMember(dest => dest.Priority, src => src.MapFrom(src => src.Priority))
               .ForMember(dest => dest.Category, src => src.MapFrom(src => src.Category))
               .ForMember(dest => dest.Address, src => src.MapFrom(src => new AddressDto
               {
                   Street = src.Address.Street,
                   StreetNumber = src.Address.StreetNumber,
                   Complement = src.Address.Complement,
                   District = src.Address.District,
                   City = src.Address.City,
                   State = src.Address.State,
                   ZipCode = src.Address.ZipCode
               }));
        }
    }
}