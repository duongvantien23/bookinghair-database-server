using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public interface ICustomerReviewRepository
    {
        bool Create(CustomerReviewModel review);         
        bool Update(CustomerReviewModel review);        
        bool Delete(int reviewId);                      
        List<CustomerReviewModel> GetAll();           
        CustomerReviewModel GetById(int reviewId);       
        List<CustomerReviewModel> GetByServiceId(int serviceId); 
    }
}
