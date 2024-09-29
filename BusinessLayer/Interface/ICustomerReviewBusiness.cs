using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface ICustomerReviewBusiness
    {
        bool CreateCustomerReview(CustomerReviewModel review);    
        bool UpdateCustomerReview(CustomerReviewModel review);    
        bool DeleteCustomerReview(int reviewId);                  
        List<CustomerReviewModel> GetAllCustomerReviews();        
        CustomerReviewModel GetCustomerReviewById(int reviewId);   
        List<CustomerReviewModel> GetCustomerReviewsByServiceId(int serviceId);  
    }
}
