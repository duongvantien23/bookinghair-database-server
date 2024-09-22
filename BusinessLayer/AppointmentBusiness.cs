using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class AppointmentBusiness : IAppointmentBusiness
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentBusiness(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public bool CreateAppointment(AppointmentModel appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public bool UpdateAppointment(AppointmentModel appointment)
        {
            return _appointmentRepository.Update(appointment);
        }

        public bool DeleteAppointment(int appointmentId)
        {
            return _appointmentRepository.Delete(appointmentId);
        }

        public List<AppointmentModel> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public AppointmentModel GetAppointmentById(int appointmentId)
        {
            return _appointmentRepository.GetById(appointmentId);
        }

        public List<AppointmentModel> GetAppointmentsByCustomer(int customerId)
        {
            return _appointmentRepository.GetByCustomer(customerId);
        }

        public List<AppointmentModel> GetAppointmentsBySalon(int salonId)
        {
            return _appointmentRepository.GetBySalon(salonId);
        }

        public bool UpdateAppointmentStatus(int appointmentId, string status)
        {
            return _appointmentRepository.UpdateStatus(appointmentId, status);
        }
    }
}
