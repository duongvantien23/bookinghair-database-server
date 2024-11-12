using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStatusClientController : ControllerBase
    {
        private readonly IAppointmentStatusBusiness _appointmentStatusBusiness;

        public AppointmentStatusClientController(IAppointmentStatusBusiness appointmentStatusBusiness)
        {
            _appointmentStatusBusiness = appointmentStatusBusiness;
        }

        // Route: GET api/appointmentstatusclient/get-all
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

        // Route: GET api/appointmentstatusclient/get-by-id/{id}
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
    }
}
