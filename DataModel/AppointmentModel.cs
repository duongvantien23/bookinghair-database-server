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
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AppointmentModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public class AppointmentUserModel
        {
            public int AppointmentId { get; set; }
            public int CustomerId { get; set; }
            public int SalonId { get; set; }
            public int? HairstylistId { get; set; }
            public int ServiceId { get; set; }
            public int TimeSlotId { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string Notes { get; set; }
            public int StatusId { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime UpdatedAt { get; set; } = DateTime.Now;
            public List<CustomerModel> ListJsonCustomer { get; set; } = new List<CustomerModel>();

            public AppointmentUserModel()
            {
                CreatedAt = DateTime.Now;
                UpdatedAt = DateTime.Now;
            }
        }

    }
}
