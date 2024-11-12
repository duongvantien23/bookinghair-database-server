using DataModel;
using System.Collections.Generic;
using static DataModel.AppointmentModel;

namespace BusinessLayer.Interface
{
    public partial interface IAppointmentBusiness
    {
        bool CreateAppointment(AppointmentModel appointment);     
        bool UpdateAppointment(AppointmentModel appointment);    
        bool DeleteAppointment(int appointmentId);               
        List<AppointmentModel> GetAllAppointments();             
        AppointmentModel GetAppointmentById(int appointmentId);   
        List<AppointmentModel> GetAppointmentsByCustomer(int customerId);  
        List<AppointmentModel> GetAppointmentsBySalon(int salonId);
        bool CreateAppointmentForUser(AppointmentUserModel appointmentUser);
    }
}
