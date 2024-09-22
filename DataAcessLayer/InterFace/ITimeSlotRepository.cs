using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public interface ITimeSlotRepository
    {
        bool Create(TimeSlotModel timeSlot);
        bool Update(TimeSlotModel timeSlot);
        bool Delete(int timeSlotId);
        List<TimeSlotModel> GetAll();
        TimeSlotModel GetById(int timeSlotId);
        bool UpdateAvailability(int timeSlotId, bool isAvailable);
    }
}
