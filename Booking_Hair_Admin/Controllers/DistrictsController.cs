using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictsBusiness _districtsBusiness;

        public DistrictsController(IDistrictsBusiness districtsBusiness)
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

        // Route: POST create/api/districts
        [HttpPost("create")]
        public ActionResult CreateDistrict([FromBody] DistrictsModel district)
        {
            if (district == null)
            {
                return BadRequest("Invalid district data.");
            }
            var result = _districtsBusiness.CreateDistrict(district);
            if (!result)
            {
                return StatusCode(500, "Error creating district.");
            }
            return Ok("District created successfully.");
        }

        // Route: PUT update/api/districts
        [HttpPut("update")]
        public ActionResult UpdateDistrict([FromBody] DistrictsModel district)
        {
            if (district == null)
            {
                return BadRequest("Invalid district data.");
            }
            var result = _districtsBusiness.UpdateDistrict(district);
            if (!result)
            {
                return StatusCode(500, "Error updating district.");
            }
            return Ok("District updated successfully.");
        }

        // Route: DELETE delete/api/districts/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteDistrict(int id)
        {
            var result = _districtsBusiness.DeleteDistrict(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting district.");
            }
            return Ok("District deleted successfully.");
        }
    }
}
