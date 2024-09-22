using System;

namespace DataModel
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int SalonId { get; set; }
        public int? HairstylistId { get; set; } 
        public int ServiceId { get; set; }
        public int TimeSlotId { get; set; }     
        public DateTime AppointmentDate { get; set; }  
        public string Notes { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AppointmentModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
