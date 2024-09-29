using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CustomerReviewBusiness : ICustomerReviewBusiness
    {
        private readonly ICustomerReviewRepository _customerReviewRepository;

        public CustomerReviewBusiness(ICustomerReviewRepository customerReviewRepository)
        {
            _customerReviewRepository = customerReviewRepository;
        }

        public bool CreateCustomerReview(CustomerReviewModel review)
        {
            return _customerReviewRepository.Create(review);
        }

        public bool UpdateCustomerReview(CustomerReviewModel review)
        {
            return _customerReviewRepository.Update(review);
        }

        public bool DeleteCustomerReview(int reviewId)
        {
            return _customerReviewRepository.Delete(reviewId);
        }

        public List<CustomerReviewModel> GetAllCustomerReviews()
        {
            return _customerReviewRepository.GetAll();
        }

        public CustomerReviewModel GetCustomerReviewById(int reviewId)
        {
            return _customerReviewRepository.GetById(reviewId);
        }

        public List<CustomerReviewModel> GetCustomerReviewsByServiceId(int serviceId)
        {
            return _customerReviewRepository.GetByServiceId(serviceId);
        }
    }
}
