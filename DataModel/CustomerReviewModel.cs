using System;

namespace DataModel
{
    public class CustomerReviewModel
    {
        public int ReviewId { get; set; }          
        public int CustomerId { get; set; }         
        public int ServiceId { get; set; }        
        public int Rating { get; set; }            
        public string Comment { get; set; }        
        public DateTime CreatedAt { get; set; }    
        public DateTime UpdatedAt { get; set; }    

        public CustomerReviewModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
