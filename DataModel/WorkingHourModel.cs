using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class WorkingHourModel
    {
        public int WorkingHourId { get; set; }
        public int HairstylistId { get; set; }
        public DateTime WorkDay { get; set; }  
        public TimeSpan StartTime { get; set; }  
        public TimeSpan EndTime { get; set; }  
    }
}
