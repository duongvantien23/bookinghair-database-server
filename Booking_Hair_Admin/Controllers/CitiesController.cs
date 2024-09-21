using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesBusiness _citiesBusiness;

        public CitiesController(ICitiesBusiness citiesBusiness)
        {
            _citiesBusiness = citiesBusiness;
        }

        // Route: GET get-all/api/cities
        [HttpGet("get-all")]
        public ActionResult<List<CitiesModel>> GetAllCities()
        {
            var cities = _citiesBusiness.GetAllCities();
            if (cities == null || cities.Count == 0)
            {
                return NotFound("No cities found.");
            }
            return Ok(cities);
        }

        // Route: GET get-by-id/api/cities/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<CitiesModel> GetCityById(int id)
        {
            var city = _citiesBusiness.GetCityById(id);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            return Ok(city);
        }

        // Route: POST create/api/cities
        [HttpPost("create")]
        public ActionResult CreateCity([FromBody] CitiesModel city)
        {
            if (city == null)
            {
                return BadRequest("Invalid city data.");
            }
            var result = _citiesBusiness.CreateCity(city);
            if (!result)
            {
                return StatusCode(500, "Error creating city.");
            }
            return Ok("City created successfully.");
        }

        // Route: PUT update/api/cities
        [HttpPut("update")]
        public ActionResult UpdateCity([FromBody] CitiesModel city)
        {
            if (city == null)
            {
                return BadRequest("Invalid city data.");
            }
            var result = _citiesBusiness.UpdateCity(city);
            if (!result)
            {
                return StatusCode(500, "Error updating city.");
            }
            return Ok("City updated successfully.");
        }

        // Route: DELETE delete/api/cities/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCity(int id)
        {
            var result = _citiesBusiness.DeleteCity(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting city.");
            }
            return Ok("City deleted successfully.");
        }
    }
}
