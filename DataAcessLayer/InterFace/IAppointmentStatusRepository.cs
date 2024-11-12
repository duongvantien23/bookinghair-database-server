using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.InterFace
{
    public partial interface IAppointmentStatusRepository
    {
        bool Create(AppointmentStatusModel status);
        bool Update(AppointmentStatusModel status);
        bool Delete(int statusId);
        List<AppointmentStatusModel> GetAll();
        AppointmentStatusModel GetById(int statusId);
    }
}
