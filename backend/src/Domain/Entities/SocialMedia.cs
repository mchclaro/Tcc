using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public int BusinessId { get; set; }
        public virtual Business Business { get; set; }
    }
}