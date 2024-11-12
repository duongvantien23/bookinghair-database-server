using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using DataModel;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategorieController : ControllerBase
    {
        private readonly IServiceCategorieBusiness _serviceCategorieBusiness;

        public ServiceCategorieController(IServiceCategorieBusiness serviceCategorieBusiness)
        {
            _serviceCategorieBusiness = serviceCategorieBusiness;
        }

        // GET: api/ServiceCategorie/get-all
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

        // GET: api/ServiceCategorie/get-by-id/{id}
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

        // POST: api/ServiceCategorie/create
        [HttpPost("create")]
        public ActionResult CreateCategory([FromBody] ServiceCategorieModel category)
        {
            if (category == null)
            {
                return BadRequest("Invalid category data.");
            }
            var result = _serviceCategorieBusiness.CreateCategory(category);
            if (!result)
            {
                return StatusCode(500, "Error creating service category.");
            }
            return Ok("Service category created successfully.");
        }

        // PUT: api/ServiceCategorie/update
        [HttpPut("update")]
        public ActionResult UpdateCategory([FromBody] ServiceCategorieModel category)
        {
            if (category == null)
            {
                return BadRequest("Invalid category data.");
            }
            var result = _serviceCategorieBusiness.UpdateCategory(category);
            if (!result)
            {
                return StatusCode(500, "Error updating service category.");
            }
            return Ok("Service category updated successfully.");
        }

        // DELETE: api/ServiceCategorie/delete/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var result = _serviceCategorieBusiness.DeleteCategory(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting service category.");
            }
            return Ok("Service category deleted successfully.");
        }
        // GET: api/ServiceCategorie/get-services-by-category-id/{id}
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
