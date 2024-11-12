using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using DataModel;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsClientController : ControllerBase
    {
        private readonly IDistrictsBusiness _districtsBusiness;

        public DistrictsClientController(IDistrictsBusiness districtsBusiness)
        {
            _districtsBusiness = districtsBusiness;
        }

        // Route: GET get-all/api/districts
        [HttpGet("get-all")]
        public ActionResult<List<DistrictsModel>> GetAllDistricts()
        {
            var districts = _districtsBusiness.GetAllDistricts();
            if (districts == null || districts.Count == 0)
            {
                return NotFound("No districts found.");
            }
            return Ok(districts);
        }

        // Route: GET get-by-id/api/districts/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<DistrictsModel> GetDistrictById(int id)
        {
            var district = _districtsBusiness.GetDistrictById(id);
            if (district == null)
            {
                return NotFound($"District with ID {id} not found.");
            }
            return Ok(district);
        }
    }
}
