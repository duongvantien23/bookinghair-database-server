using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentBusiness _appointmentBusiness;

        public AppointmentController(IAppointmentBusiness appointmentBusiness)
        {
            _appointmentBusiness = appointmentBusiness;
        }

        // Route: GET get-all/api/appointments
        [HttpGet("get-all")]
        public ActionResult<List<AppointmentModel>> GetAllAppointments()
        {
            var appointments = _appointmentBusiness.GetAllAppointments();
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound("No appointments found.");
            }
            return Ok(appointments);
        }

        // Route: GET get-by-id/api/appointments/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<AppointmentModel> GetAppointmentById(int id)
        {
            var appointment = _appointmentBusiness.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }
            return Ok(appointment);
        }

        // Route: GET get-by-customer/api/appointments/customer/{customerId}
        [HttpGet("get-by-customer/{customerId}")]
        public ActionResult<List<AppointmentModel>> GetAppointmentsByCustomer(int customerId)
        {
            var appointments = _appointmentBusiness.GetAppointmentsByCustomer(customerId);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound($"No appointments found for customer with ID {customerId}.");
            }
            return Ok(appointments);
        }

        // Route: GET get-by-salon/api/appointments/salon/{salonId}
        [HttpGet("get-by-salon/{salonId}")]
        public ActionResult<List<AppointmentModel>> GetAppointmentsBySalon(int salonId)
        {
            var appointments = _appointmentBusiness.GetAppointmentsBySalon(salonId);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound($"No appointments found for salon with ID {salonId}.");
            }
            return Ok(appointments);
        }

        // Route: POST create/api/appointments
        [HttpPost("create")]
        public ActionResult CreateAppointment([FromBody] AppointmentModel appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Invalid appointment data.");
            }

            var result = _appointmentBusiness.CreateAppointment(appointment);
            if (!result)
            {
                return StatusCode(500, "Error creating appointment.");
            }
            return Ok("Appointment created successfully.");
        }

        // Route: PUT update/api/appointments
        [HttpPut("update")]
        public ActionResult UpdateAppointment([FromBody] AppointmentModel appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Invalid appointment data.");
            }

            var result = _appointmentBusiness.UpdateAppointment(appointment);
            if (!result)
            {
                return StatusCode(500, "Error updating appointment.");
            }
            return Ok("Appointment updated successfully.");
        }

        // Route: PUT update-status/api/appointments/{id}
        [HttpPut("update-status/{id}")]
        public ActionResult UpdateAppointmentStatus(int id, [FromBody] string status)
        {
            var result = _appointmentBusiness.UpdateAppointmentStatus(id, status);
            if (!result)
            {
                return StatusCode(500, "Error updating appointment status.");
            }
            return Ok("Appointment status updated successfully.");
        }

        // Route: DELETE delete/api/appointments/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteAppointment(int id)
        {
            var result = _appointmentBusiness.DeleteAppointment(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting appointment.");
            }
            return Ok("Appointment deleted successfully.");
        }
    }
}
