using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerClientController : ControllerBase
    {
        private readonly ICustomerBusiness _customerBusiness;

        public CustomerClientController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        // Route: GET api/customerclient/get-all
        [HttpGet("get-all")]
        public ActionResult<List<CustomerModel>> GetAllCustomers()
        {
            var customers = _customerBusiness.GetAllCustomers();
            if (customers == null || customers.Count == 0)
            {
                return NotFound("No customers found.");
            }
            return Ok(customers);
        }

        // Route: GET api/customerclient/get-by-id/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<CustomerModel> GetCustomerById(int id)
        {
            var customer = _customerBusiness.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            return Ok(customer);
        }
    }
}
