using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface ITimeSlotBusiness
    {
        bool CreateTimeSlot(TimeSlotModel timeSlot);
        bool UpdateTimeSlot(TimeSlotModel timeSlot);
        bool DeleteTimeSlot(int timeSlotId);
        List<TimeSlotModel> GetAllTimeSlots();
        TimeSlotModel GetTimeSlotById(int timeSlotId);
        bool UpdateAvailability(int timeSlotId, bool isAvailable);
        List<TimeSlotModel> GetTimeSlotsBySalonId(int salonId);
        List<TimeSlotModel> GetTimeSlotsForToday(int salonId);
        List<TimeSlotModel> GetTimeSlotsForTomorrow(int salonId);
    }
}
