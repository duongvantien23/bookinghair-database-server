using System;

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

        // Constructor
        public ServiceDetailModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
