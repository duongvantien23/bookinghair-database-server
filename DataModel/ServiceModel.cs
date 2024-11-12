using System;
using System.Collections.Generic;

namespace DataModel
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public string NameService { get; set; }
        public string Description { get; set; }
        public string ImageServices { get; set; } 
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
