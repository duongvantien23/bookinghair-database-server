using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStatusController : ControllerBase
    {
        private readonly IAppointmentStatusBusiness _appointmentStatusBusiness;

        public AppointmentStatusController(IAppointmentStatusBusiness appointmentStatusBusiness)
        {
            _appointmentStatusBusiness = appointmentStatusBusiness;
        }

        // Route: GET api/appointmentstatus/get-all
        [HttpGet("get-all")]
        public ActionResult<List<AppointmentStatusModel>> GetAllStatuses()
        {
            try
            {
                var statuses = _appointmentStatusBusiness.GetAllStatuses();
                if (statuses == null || statuses.Count == 0)
                {
                    return NotFound("No appointment statuses found.");
                }
                return Ok(statuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Route: GET api/appointmentstatus/get-by-id/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<AppointmentStatusModel> GetStatusById(int id)
        {
            try
            {
                var status = _appointmentStatusBusiness.GetStatusById(id);
                if (status == null)
                {
                    return NotFound($"Appointment status with ID {id} not found.");
                }
                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Route: POST api/appointmentstatus/create
        [HttpPost("create")]
        public ActionResult CreateStatus([FromBody] AppointmentStatusModel status)
        {
            try
            {
                if (status == null)
                {
                    return BadRequest("Invalid appointment status data.");
                }
                var result = _appointmentStatusBusiness.CreateStatus(status);
                if (!result)
                {
                    return StatusCode(500, "Error creating appointment status.");
                }
                return Ok("Appointment status created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Route: PUT api/appointmentstatus/update
        [HttpPut("update")]
        public ActionResult UpdateStatus([FromBody] AppointmentStatusModel status)
        {
            try
            {
                if (status == null)
                {
                    return BadRequest("Invalid appointment status data.");
                }
                var result = _appointmentStatusBusiness.UpdateStatus(status);
                if (!result)
                {
                    return StatusCode(500, "Error updating appointment status.");
                }
                return Ok("Appointment status updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Route: DELETE api/appointmentstatus/delete/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteStatus(int id)
        {
            try
            {
                var result = _appointmentStatusBusiness.DeleteStatus(id);
                if (!result)
                {
                    return StatusCode(500, "Error deleting appointment status.");
                }
                return Ok("Appointment status deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
