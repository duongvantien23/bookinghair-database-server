using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using DataModel;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategorieClientController : ControllerBase
    {
        private readonly IServiceCategorieBusiness _serviceCategorieBusiness;

        public ServiceCategorieClientController(IServiceCategorieBusiness serviceCategorieBusiness)
        {
            _serviceCategorieBusiness = serviceCategorieBusiness;
        }

        // GET: api/ServiceCategorieClient/get-all
        [HttpGet("get-all")]
        public ActionResult<List<ServiceCategorieModel>> GetAllCategories()
        {
            var categories = _serviceCategorieBusiness.GetAllCategories();
            if (categories == null || categories.Count == 0)
            {
                return NotFound("No service categories found.");
            }
            return Ok(categories);
        }

        // GET: api/ServiceCategorieClient/get-by-id/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<ServiceCategorieModel> GetCategoryById(int id)
        {
            var category = _serviceCategorieBusiness.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"Service category with ID {id} not found.");
            }
            return Ok(category);
        }

        // GET: api/ServiceCategorieClient/get-services-by-category-id/{id}
        [HttpGet("get-services-by-category-id/{id}")]
        public ActionResult<List<ServiceModel>> GetServicesByCategoryId(int id)
        {
            var services = _serviceCategorieBusiness.GetServicesByCategoryId(id);
            if (services == null || services.Count == 0)
            {
                return NotFound($"No services found for category ID {id}.");
            }
            return Ok(services);
        }
    }
}
