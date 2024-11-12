using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceClientController : ControllerBase
    {
        private readonly IServiceBusiness _serviceBusiness;

        public ServiceClientController(IServiceBusiness serviceBusiness)
        {
            _serviceBusiness = serviceBusiness;
        }

        // Route: GET api/serviceclient/get-all
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

        // Route: GET api/serviceclient/get-by-id/{id}
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

        // Route: GET api/serviceclient/get-service-details-by-service-id/{id}
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
    }
}
