using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class AppointmentStatusBusiness : IAppointmentStatusBusiness
    {
        private readonly IAppointmentStatusRepository _appointmentStatusRepository;

        public AppointmentStatusBusiness(IAppointmentStatusRepository appointmentStatusRepository)
        {
            _appointmentStatusRepository = appointmentStatusRepository;
        }

        public bool CreateStatus(AppointmentStatusModel status)
        {
            return _appointmentStatusRepository.Create(status);
        }

        public bool UpdateStatus(AppointmentStatusModel status)
        {
            return _appointmentStatusRepository.Update(status);
        }

        public bool DeleteStatus(int statusId)
        {
            return _appointmentStatusRepository.Delete(statusId);
        }

        public List<AppointmentStatusModel> GetAllStatuses()
        {
            return _appointmentStatusRepository.GetAll();
        }

        public AppointmentStatusModel GetStatusById(int statusId)
        {
            return _appointmentStatusRepository.GetById(statusId);
        }
    }
}
