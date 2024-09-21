using System;
using System.Collections.Generic;

namespace DataModel
{
    public class ServiceModel
    {
        public int ServiceId { get; set; } 
        public string NameService { get; set; } 
        public string Description { get; set; } 
        public string ImageService { get; set; } 
        public decimal Price { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public List<ServiceDetailModel> ListJsonDetailService { get; set; } 

        // Constructor khởi tạo đối tượng
        public ServiceModel()
        {
            ListJsonDetailService = new List<ServiceDetailModel>(); 
        }
    }
}
