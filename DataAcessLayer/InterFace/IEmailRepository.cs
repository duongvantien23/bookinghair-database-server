using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.InterFace
{
    public partial interface IEmailRepository
    {
        Task SendAppointmentSuccessEmailAsync(
            string email, string customerName, string cityName, string districtName,
            string salonName, string hairstylistName, string serviceName, DateTime dateAvailable,
            string timeSlot, string phone, string notes, DateTime appointmentDate);
    }
}
