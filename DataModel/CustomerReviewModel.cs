using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CustomerReviewModel
    {
        public int ReviewId { get; set; }           
        public int CustomerId { get; set; }         
        public int ServiceId { get; set; }          
        public int Rating { get; set; }              // Đánh giá từ 1 đến 5 sao
        public string Comment { get; set; }          
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
