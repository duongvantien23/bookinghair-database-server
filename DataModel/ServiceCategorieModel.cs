using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ServiceCategorieModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 
        public string Description { get; set; } 
        public string ImageServiceCategory { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
