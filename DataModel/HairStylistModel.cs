using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HairStylistModel
    {
        public int HairstylistId { get; set; }
        public int SalonId { get; set; }
        public string NameStylist { get; set; }
        public string Phone { get; set; }
        public string MainImage { get; set; }
        public decimal Salary { get; set; }  
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
