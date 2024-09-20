using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<ServiceDetailModel> list_json_detail_service { get; set; }
    }
}
