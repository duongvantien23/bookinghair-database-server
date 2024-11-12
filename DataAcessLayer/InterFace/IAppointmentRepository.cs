using DataModel;
using System.Collections.Generic;
using static DataModel.AppointmentModel;

namespace DataAcessLayer.InterFace
{
    public partial interface IAppointmentRepository
    {
        bool Create(AppointmentModel appointment);         
        bool Update(AppointmentModel appointment);         
        bool Delete(int appointmentId);                  
        List<AppointmentModel> GetAll();                  
        AppointmentModel GetById(int appointmentId);     
        List<AppointmentModel> GetByCustomer(int customerId);  
        List<AppointmentModel> GetBySalon(int salonId);
        bool CreateAppointmentForUser(AppointmentUserModel appointmentUser);
    }
}
