using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusiness _customerBusiness;

        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        // Route: GET get-all/api/customer
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

        // Route: GET get-by-id/api/customer/{id}
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

        // Route: POST create/api/customer
        [HttpPost("create")]
        public ActionResult CreateCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid customer data.");
            }
            var result = _customerBusiness.CreateCustomer(customer);
            if (!result)
            {
                return StatusCode(500, "Error creating customer.");
            }
            return Ok("Customer created successfully.");
        }

        // Route: PUT update/api/customer
        [HttpPut("update")]
        public ActionResult UpdateCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid customer data.");
            }
            var result = _customerBusiness.UpdateCustomer(customer);
            if (!result)
            {
                return StatusCode(500, "Error updating customer.");
            }
            return Ok("Customer updated successfully.");
        }

        // Route: DELETE delete/api/customer/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var result = _customerBusiness.DeleteCustomer(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting customer.");
            }
            return Ok("Customer deleted successfully.");
        }
    }
}
