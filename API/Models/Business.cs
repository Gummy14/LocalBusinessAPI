using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string AddressCountry { get; set; }
        public string PhoneNumber { get; set; }
    }
}
