using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailController : ControllerBase
    {
        private readonly IServiceDetailBusiness _serviceDetailBusiness;

        public ServiceDetailController(IServiceDetailBusiness serviceDetailBusiness)
        {
            _serviceDetailBusiness = serviceDetailBusiness;
        }

        // Route: GET get-all/api/service-details
        [HttpGet("get-all")]
        public ActionResult<List<ServiceDetailModel>> GetAllServiceDetails()
        {
            var serviceDetails = _serviceDetailBusiness.GetAllServiceDetails();
            if (serviceDetails == null || serviceDetails.Count == 0)
            {
                return NotFound("No service details found.");
            }
            return Ok(serviceDetails);
        }

        // Route: GET get-by-id/api/service-details/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<ServiceDetailModel> GetServiceDetailById(int id)
        {
            var serviceDetail = _serviceDetailBusiness.GetServiceDetailById(id);
            if (serviceDetail == null)
            {
                return NotFound($"Service detail with ID {id} not found.");
            }
            return Ok(serviceDetail);
        }

        // Route: POST create/api/service-details
        [HttpPost("create")]
        public ActionResult CreateServiceDetail([FromBody] ServiceDetailModel serviceDetail)
        {
            if (serviceDetail == null)
            {
                return BadRequest("Invalid service detail data.");
            }
            var result = _serviceDetailBusiness.CreateServiceDetail(serviceDetail);
            if (!result)
            {
                return StatusCode(500, "Error creating service detail.");
            }
            return Ok("Service detail created successfully.");
        }

        // Route: PUT update/api/service-details
        [HttpPut("update")]
        public ActionResult UpdateServiceDetail([FromBody] ServiceDetailModel serviceDetail)
        {
            if (serviceDetail == null)
            {
                return BadRequest("Invalid service detail data.");
            }
            var result = _serviceDetailBusiness.UpdateServiceDetail(serviceDetail);
            if (!result)
            {
                return StatusCode(500, "Error updating service detail.");
            }
            return Ok("Service detail updated successfully.");
        }

        // Route: DELETE delete/api/service-details/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteServiceDetail(int id)
        {
            var result = _serviceDetailBusiness.DeleteServiceDetail(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting service detail.");
            }
            return Ok("Service detail deleted successfully.");
        }
    }
}
