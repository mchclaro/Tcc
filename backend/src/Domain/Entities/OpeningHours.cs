using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class OpeningHours
    {
        public int Id { get; set; }
        public ulong Start { get; set; }
        public ulong End { get; set; }
        public ulong Break { get; set; }
        public Weekday DayOfWeek { get; set; }
        public int BusinessId { get; set; }
        public virtual Business Business { get; set; }
    }
}