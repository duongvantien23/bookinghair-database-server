using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHourController : ControllerBase
    {
        private readonly IWorkingHourBusiness _workingHourBusiness;

        public WorkingHourController(IWorkingHourBusiness workingHourBusiness)
        {
            _workingHourBusiness = workingHourBusiness;
        }

        // Route: GET get-all-by-hairstylist/api/working-hours/{hairstylistId}
        [HttpGet("get-all-by-hairstylist/{hairstylistId}")]
        public ActionResult<List<WorkingHourModel>> GetAllByHairstylist(int hairstylistId)
        {
            var workingHours = _workingHourBusiness.GetWorkingHoursByHairstylist(hairstylistId);
            if (workingHours == null || workingHours.Count == 0)
            {
                return NotFound("No working hours found for this hairstylist.");
            }
            return Ok(workingHours);
        }

        // Route: GET get-by-id/api/working-hours/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<WorkingHourModel> GetById(int id)
        {
            var workingHour = _workingHourBusiness.GetWorkingHourById(id);
            if (workingHour == null)
            {
                return NotFound($"Working hour with ID {id} not found.");
            }
            return Ok(workingHour);
        }

        // Route: POST create/api/working-hours
        [HttpPost("create")]
        public ActionResult Create([FromBody] WorkingHourModel workingHour)
        {
            if (workingHour == null)
            {
                return BadRequest("Invalid working hour data.");
            }
            var result = _workingHourBusiness.CreateWorkingHour(workingHour);
            if (!result)
            {
                return StatusCode(500, "Error creating working hour.");
            }
            return Ok("Working hour created successfully.");
        }

        // Route: PUT update/api/working-hours
        [HttpPut("update")]
        public ActionResult Update([FromBody] WorkingHourModel workingHour)
        {
            if (workingHour == null)
            {
                return BadRequest("Invalid working hour data.");
            }
            var result = _workingHourBusiness.UpdateWorkingHour(workingHour);
            if (!result)
            {
                return StatusCode(500, "Error updating working hour.");
            }
            return Ok("Working hour updated successfully.");
        }

        // Route: DELETE delete/api/working-hours/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var result = _workingHourBusiness.DeleteWorkingHour(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting working hour.");
            }
            return Ok("Working hour deleted successfully.");
        }

        // Route: GET check-availability/api/working-hours/check-availability
        [HttpGet("check-availability")]
        public ActionResult CheckAvailability(int hairstylistId, DateTime workDay, TimeSpan startTime, TimeSpan endTime)
        {
            var isAvailable = _workingHourBusiness.CheckAvailability(hairstylistId, workDay, startTime, endTime);
            if (!isAvailable)
            {
                return Conflict("The hairstylist is not available at the selected time.");
            }
            return Ok("The hairstylist is available.");
        }
    }
}
