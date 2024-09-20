using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class SalonModel
    {
        public int SalonId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string NameSalon { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MainImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
