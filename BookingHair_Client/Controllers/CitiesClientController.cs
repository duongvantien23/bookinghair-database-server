using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using DataModel;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesClientController : ControllerBase
    {
        private readonly ICitiesBusiness _citiesBusiness;

        public CitiesClientController(ICitiesBusiness citiesBusiness)
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
    }
}
