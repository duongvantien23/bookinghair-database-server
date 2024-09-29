using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IAppointmentBusiness
    {
        bool CreateAppointment(AppointmentModel appointment);     
        bool UpdateAppointment(AppointmentModel appointment);    
        bool DeleteAppointment(int appointmentId);               
        List<AppointmentModel> GetAllAppointments();             
        AppointmentModel GetAppointmentById(int appointmentId);   
        List<AppointmentModel> GetAppointmentsByCustomer(int customerId);  
        List<AppointmentModel> GetAppointmentsBySalon(int salonId);        
        bool UpdateAppointmentStatus(int appointmentId, string status);    
    }
}
