using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using DataModel;
using static DataModel.AppointmentModel;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentClientController : ControllerBase
    {
        private readonly IAppointmentBusiness _appointmentBusiness;

        public AppointmentClientController(IAppointmentBusiness appointmentBusiness)
        {
            _appointmentBusiness = appointmentBusiness;
        }

        [HttpPost("create")]
        public IActionResult CreateAppointmentForUser([FromBody] AppointmentUserModel appointmentUser)
        {
            if (appointmentUser == null)
            {
                return BadRequest("Invalid appointment data.");
            }

            var result = _appointmentBusiness.CreateAppointmentForUser(appointmentUser);

            if (!result)
            {
                return StatusCode(500, "Error creating appointment for user.");
            }

            return Ok("Appointment created successfully.");
        }
    }
}
