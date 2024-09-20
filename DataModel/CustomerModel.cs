using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string NameCustomer { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
