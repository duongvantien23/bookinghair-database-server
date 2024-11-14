using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmailBusiness
    {
        Task SendAppointmentSuccessEmailAsync(
            string email, string customerName, string cityName, string districtName,
            string salonName, string hairstylistName, string serviceName, DateTime dateAvailable,
            string timeSlot, string phone, string notes, DateTime appointmentDate);
    }
}
