using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TimeSlotModel
    {
        public int TimeSlotId { get; set; }      
        public string TimeSlot { get; set; }     
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }  
    }
}
