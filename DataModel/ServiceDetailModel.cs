using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ServiceDetailModel
    {
        public int ServiceDetailId { get; set; }
        public int ServiceId { get; set; }
        public string StepDescription { get; set; }
        public string ImageDetails { get; set; }
        public int StepOrder { get; set; }             
        public DateTime CreatedAt { get; set; }        
        public DateTime UpdatedAt { get; set; }          
    }
}
