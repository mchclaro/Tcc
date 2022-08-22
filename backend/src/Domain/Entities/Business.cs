using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Business
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string SocialReson { get; set; }
        public string FantasyName { get; set; }
        public string BusinessName { get; set; }
        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<BusinessPhotos> BusinessPhotos { get; set; }
        public virtual ICollection<OpeningHours> OpeningHours { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }
    }
}