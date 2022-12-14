using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Domain.DTO.Business
{
    public class ListBusinessDTO
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string SocialReson { get; set; }
        public string FantasyName { get; set; }
        public string BusinessName { get; set; }
        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public string MainImage { get; set; }
        public AddressDto Address { get; set; }
        public SocialMediaDto SocialMedias { get; set; }
        public virtual ICollection<BusinessPhotos> BusinessPhotos { get; set; }
        public virtual ICollection<OpeningHours> OpeningHours { get; set; }
    }

    public class AddressDto
    {
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class SocialMediaDto
    {
        public string Phone { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
    }
}