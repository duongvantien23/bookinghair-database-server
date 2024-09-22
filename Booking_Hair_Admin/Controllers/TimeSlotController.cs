using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotBusiness _timeSlotBusiness;

        public TimeSlotController(ITimeSlotBusiness timeSlotBusiness)
        {
            _timeSlotBusiness = timeSlotBusiness;
        }

        // Route: GET get-all/api/timeslots
        [HttpGet("get-all")]
        public ActionResult<List<TimeSlotModel>> GetAllTimeSlots()
        {
            var timeSlots = _timeSlotBusiness.GetAllTimeSlots();
            if (timeSlots == null || timeSlots.Count == 0)
            {
                return NotFound("No time slots found.");
            }
            return Ok(timeSlots);
        }

        // Route: GET get-by-id/api/timeslots/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<TimeSlotModel> GetTimeSlotById(int id)
        {
            var timeSlot = _timeSlotBusiness.GetTimeSlotById(id);
            if (timeSlot == null)
            {
                return NotFound($"Time slot with ID {id} not found.");
            }
            return Ok(timeSlot);
        }

        // Route: POST create/api/timeslots
        [HttpPost("create")]
        public ActionResult CreateTimeSlot([FromBody] TimeSlotModel timeSlot)
        {
            if (timeSlot == null)
            {
                return BadRequest("Invalid time slot data.");
            }
            var result = _timeSlotBusiness.CreateTimeSlot(timeSlot);
            if (!result)
            {
                return StatusCode(500, "Error creating time slot.");
            }
            return Ok("Time slot created successfully.");
        }

        // Route: PUT update/api/timeslots
        [HttpPut("update")]
        public ActionResult UpdateTimeSlot([FromBody] TimeSlotModel timeSlot)
        {
            if (timeSlot == null)
            {
                return BadRequest("Invalid time slot data.");
            }
            var result = _timeSlotBusiness.UpdateTimeSlot(timeSlot);
            if (!result)
            {
                return StatusCode(500, "Error updating time slot.");
            }
            return Ok("Time slot updated successfully.");
        }

        // Route: PUT update-availability/api/timeslots/{id}
        [HttpPut("update-availability/{id}")]
        public ActionResult UpdateAvailability(int id, [FromBody] bool isAvailable)
        {
            var result = _timeSlotBusiness.UpdateAvailability(id, isAvailable);
            if (!result)
            {
                return StatusCode(500, "Error updating time slot availability.");
            }
            return Ok("Time slot availability updated successfully.");
        }

        // Route: DELETE delete/api/timeslots/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteTimeSlot(int id)
        {
            var result = _timeSlotBusiness.DeleteTimeSlot(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting time slot.");
            }
            return Ok("Time slot deleted successfully.");
        }
    }
}
