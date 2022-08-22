using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Product
{
    public class ListProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BusinessId { get; set; }
        public virtual Domain.Entities.Business Business { get; set; }
    }
}