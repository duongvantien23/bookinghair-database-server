using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailClientController : ControllerBase
    {
        private readonly IEmailBusiness _emailBusiness;

        public EmailClientController(IEmailBusiness emailBusiness)
        {
            _emailBusiness = emailBusiness;
        }

        [HttpPost("SendAppointmentConfirmation")]
        public async Task<IActionResult> SendAppointmentConfirmation(
            string email, string customerName, string cityName, string districtName,
            string salonName, string hairstylistName, string serviceName, DateTime dateAvailable,
            string timeSlot, string phone, string notes, DateTime appointmentDate)
        {
            try
            {
                await _emailBusiness.SendAppointmentSuccessEmailAsync(
                    email, customerName, cityName, districtName,
                    salonName, hairstylistName, serviceName, dateAvailable,
                    timeSlot, phone, notes, appointmentDate);

                return Ok(new { message = "Email xác nhận đã được gửi thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Gửi email thất bại.", details = ex.Message });
            }
        }
    }
}
