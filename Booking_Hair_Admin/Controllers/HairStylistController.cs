using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStylistController : ControllerBase
    {
        private readonly IHairStylistBusiness _hairStylistBusiness;

        public HairStylistController(IHairStylistBusiness hairStylistBusiness)
        {
            _hairStylistBusiness = hairStylistBusiness;
        }

        // Route: GET get-all/api/hairstylists
        [HttpGet("get-all")]
        public ActionResult<List<HairStylistModel>> GetAllHairStylists()
        {
            var hairstylists = _hairStylistBusiness.GetAllHairStylists();
            if (hairstylists == null || hairstylists.Count == 0)
            {
                return NotFound("No hairstylists found.");
            }
            return Ok(hairstylists);
        }

        // Route: GET get-by-id/api/hairstylists/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<HairStylistModel> GetHairStylistById(int id)
        {
            var hairstylist = _hairStylistBusiness.GetHairStylistById(id);
            if (hairstylist == null)
            {
                return NotFound($"HairStylist with ID {id} not found.");
            }
            return Ok(hairstylist);
        }

        // Route: POST create/api/hairstylists
        [HttpPost("create")]
        public ActionResult CreateHairStylist([FromBody] HairStylistModel hairstylist)
        {
            if (hairstylist == null)
            {
                return BadRequest("Invalid hairstylist data.");
            }
            var result = _hairStylistBusiness.CreateHairStylist(hairstylist);
            if (!result)
            {
                return StatusCode(500, "Error creating hairstylist.");
            }
            return Ok("HairStylist created successfully.");
        }

        // Route: PUT update/api/hairstylists
        [HttpPut("update")]
        public ActionResult UpdateHairStylist([FromBody] HairStylistModel hairstylist)
        {
            if (hairstylist == null)
            {
                return BadRequest("Invalid hairstylist data.");
            }
            var result = _hairStylistBusiness.UpdateHairStylist(hairstylist);
            if (!result)
            {
                return StatusCode(500, "Error updating hairstylist.");
            }
            return Ok("HairStylist updated successfully.");
        }

        // Route: DELETE delete/api/hairstylists/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteHairStylist(int id)
        {
            var result = _hairStylistBusiness.DeleteHairStylist(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting hairstylist.");
            }
            return Ok("HairStylist deleted successfully.");
        }
    }
}
