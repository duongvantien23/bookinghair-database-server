using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceBusiness _serviceBusiness;

        public ServiceController(IServiceBusiness serviceBusiness)
        {
            _serviceBusiness = serviceBusiness;
        }

        // Route: GET get-all/api/services
        [HttpGet("get-all")]
        public ActionResult<List<ServiceModel>> GetAllServices()
        {
            var services = _serviceBusiness.GetAllServices();
            if (services == null || services.Count == 0)
            {
                return NotFound("No services found.");
            }
            return Ok(services);
        }

        // Route: GET get-by-id/api/services/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<ServiceModel> GetServiceById(int id)
        {
            var service = _serviceBusiness.GetServiceById(id);
            if (service == null)
            {
                return NotFound($"Service with ID {id} not found.");
            }
            return Ok(service);
        }

        // Route: POST create/api/services
        [HttpPost("create")]
        public ActionResult CreateService([FromBody] ServiceModel service)
        {
            if (service == null)
            {
                return BadRequest("Invalid service data.");
            }
            var result = _serviceBusiness.CreateService(service);
            if (!result)
            {
                return StatusCode(500, "Error creating service.");
            }
            return Ok("Service created successfully.");
        }

        // Route: PUT update/api/services
        [HttpPut("update")]
        public ActionResult UpdateService([FromBody] ServiceModel service)
        {
            if (service == null)
            {
                return BadRequest("Invalid service data.");
            }
            var result = _serviceBusiness.UpdateService(service);
            if (!result)
            {
                return StatusCode(500, "Error updating service.");
            }
            return Ok("Service updated successfully.");
        }
        // Route: GET get-service-details-by-service-id/api/services/{id}
        [HttpGet("get-service-details-by-service-id/{id}")]
        public ActionResult<List<ServiceDetailModel>> GetServiceDetailsByServiceId(int id)
        {
            var serviceDetails = _serviceBusiness.GetServiceDetailsByServiceId(id);
            if (serviceDetails == null || serviceDetails.Count == 0)
            {
                return NotFound($"No service details found for Service ID {id}.");
            }
            return Ok(serviceDetails);
        }
        // Route: DELETE delete/api/services/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteService(int id)
        {
            var result = _serviceBusiness.DeleteService(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting service.");
            }
            return Ok("Service deleted successfully.");
        }
    }
}
