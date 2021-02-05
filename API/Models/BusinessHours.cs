using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BusinessHours
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }

        
    }
}
