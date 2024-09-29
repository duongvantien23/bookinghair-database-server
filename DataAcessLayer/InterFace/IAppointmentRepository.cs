using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public interface IAppointmentRepository
    {
        bool Create(AppointmentModel appointment);         
        bool Update(AppointmentModel appointment);         
        bool Delete(int appointmentId);                  
        List<AppointmentModel> GetAll();                  
        AppointmentModel GetById(int appointmentId);     
        List<AppointmentModel> GetByCustomer(int customerId);  
        List<AppointmentModel> GetBySalon(int salonId);      
        bool UpdateStatus(int appointmentId, string status);   
    }
}
