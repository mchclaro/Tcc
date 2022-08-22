using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BusinessPhotos
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string PhotoUrl { get; set; }
        public virtual Business Business { get; set; }
    }
}