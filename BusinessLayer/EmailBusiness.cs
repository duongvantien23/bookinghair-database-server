using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmailBusiness : IEmailBusiness
    {
        private readonly IEmailRepository _emailRepository;

        public EmailBusiness(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task SendAppointmentSuccessEmailAsync(
            string email, string customerName, string cityName, string districtName,
            string salonName, string hairstylistName, string serviceName, DateTime dateAvailable,
            string timeSlot, string phone, string notes, DateTime appointmentDate)
        {
            await _emailRepository.SendAppointmentSuccessEmailAsync(
                email, customerName, cityName, districtName, salonName,
                hairstylistName, serviceName, dateAvailable, timeSlot, phone, notes, appointmentDate);
        }
    }
}
