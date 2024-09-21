using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        private readonly ISalonBusiness _salonBusiness;

        public SalonController(ISalonBusiness salonBusiness)
        {
            _salonBusiness = salonBusiness;
        }

        // Route: GET get-all/api/salons
        [HttpGet("get-all")]
        public ActionResult<List<SalonModel>> GetAllSalons()
        {
            var salons = _salonBusiness.GetAllSalons();
            if (salons == null || salons.Count == 0)
            {
                return NotFound("No salons found.");
            }
            return Ok(salons);
        }

        // Route: GET get-by-id/api/salons/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<SalonModel> GetSalonById(int id)
        {
            var salon = _salonBusiness.GetSalonById(id);
            if (salon == null)
            {
                return NotFound($"Salon with ID {id} not found.");
            }
            return Ok(salon);
        }

        // Route: POST create/api/salons
        [HttpPost("create")]
        public ActionResult CreateSalon([FromBody] SalonModel salon)
        {
            if (salon == null)
            {
                return BadRequest("Invalid salon data.");
            }
            var result = _salonBusiness.CreateSalon(salon);
            if (!result)
            {
                return StatusCode(500, "Error creating salon.");
            }
            return Ok("Salon created successfully.");
        }

        // Route: PUT update/api/salons
        [HttpPut("update")]
        public ActionResult UpdateSalon([FromBody] SalonModel salon)
        {
            if (salon == null)
            {
                return BadRequest("Invalid salon data.");
            }
            var result = _salonBusiness.UpdateSalon(salon);
            if (!result)
            {
                return StatusCode(500, "Error updating salon.");
            }
            return Ok("Salon updated successfully.");
        }

        // Route: DELETE delete/api/salons/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteSalon(int id)
        {
            var result = _salonBusiness.DeleteSalon(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting salon.");
            }
            return Ok("Salon deleted successfully.");
        }
    }
}
