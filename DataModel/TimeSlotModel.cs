using System;

namespace DataModel
{
    public class TimeSlotModel
    {
        public int TimeSlotId { get; set; }      
        public string TimeSlot { get; set; }     
        public bool IsAvailable { get; set; }    
        public DateTime CreatedAt { get; set; }   
        public DateTime UpdatedAt { get; set; }   

        public TimeSlotModel()
        {
            IsAvailable = true;                  
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
