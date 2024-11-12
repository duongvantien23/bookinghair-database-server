using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public partial interface IAppointmentStatusBusiness
    {
        bool CreateStatus(AppointmentStatusModel status);
        bool UpdateStatus(AppointmentStatusModel status);
        bool DeleteStatus(int statusId);
        List<AppointmentStatusModel> GetAllStatuses();
        AppointmentStatusModel GetStatusById(int statusId);
    }
}
