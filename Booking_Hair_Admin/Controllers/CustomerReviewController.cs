using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerReviewBusiness _customerReviewBusiness;

        public CustomerReviewController(ICustomerReviewBusiness customerReviewBusiness)
        {
            _customerReviewBusiness = customerReviewBusiness;
        }

        // Route: GET get-all/api/customer-reviews
        [HttpGet("get-all")]
        public ActionResult<List<CustomerReviewModel>> GetAllCustomerReviews()
        {
            var reviews = _customerReviewBusiness.GetAllCustomerReviews();
            if (reviews == null || reviews.Count == 0)
            {
                return NotFound("No customer reviews found.");
            }
            return Ok(reviews);
        }

        // Route: GET get-by-id/api/customer-reviews/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<CustomerReviewModel> GetCustomerReviewById(int id)
        {
            var review = _customerReviewBusiness.GetCustomerReviewById(id);
            if (review == null)
            {
                return NotFound($"Customer review with ID {id} not found.");
            }
            return Ok(review);
        }

        // Route: GET get-by-service-id/api/customer-reviews/service/{serviceId}
        [HttpGet("get-by-service-id/{serviceId}")]
        public ActionResult<List<CustomerReviewModel>> GetCustomerReviewsByServiceId(int serviceId)
        {
            var reviews = _customerReviewBusiness.GetCustomerReviewsByServiceId(serviceId);
            if (reviews == null || reviews.Count == 0)
            {
                return NotFound($"No customer reviews found for service with ID {serviceId}.");
            }
            return Ok(reviews);
        }

        // Route: POST create/api/customer-reviews
        [HttpPost("create")]
        public ActionResult CreateCustomerReview([FromBody] CustomerReviewModel review)
        {
            if (review == null)
            {
                return BadRequest("Invalid customer review data.");
            }

            var result = _customerReviewBusiness.CreateCustomerReview(review);
            if (!result)
            {
                return StatusCode(500, "Error creating customer review.");
            }
            return Ok("Customer review created successfully.");
        }

        // Route: PUT update/api/customer-reviews
        [HttpPut("update")]
        public ActionResult UpdateCustomerReview([FromBody] CustomerReviewModel review)
        {
            if (review == null)
            {
                return BadRequest("Invalid customer review data.");
            }

            var result = _customerReviewBusiness.UpdateCustomerReview(review);
            if (!result)
            {
                return StatusCode(500, "Error updating customer review.");
            }
            return Ok("Customer review updated successfully.");
        }

        // Route: DELETE delete/api/customer-reviews/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCustomerReview(int id)
        {
            var result = _customerReviewBusiness.DeleteCustomerReview(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting customer review.");
            }
            return Ok("Customer review deleted successfully.");
        }
    }
}
