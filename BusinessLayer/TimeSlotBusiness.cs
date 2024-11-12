using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class TimeSlotBusiness : ITimeSlotBusiness
    {
        private readonly ITimeSlotRepository _timeSlotRepository;

        public TimeSlotBusiness(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }

        public bool CreateTimeSlot(TimeSlotModel timeSlot)
        {
            return _timeSlotRepository.Create(timeSlot);
        }

        public bool UpdateTimeSlot(TimeSlotModel timeSlot)
        {
            return _timeSlotRepository.Update(timeSlot);
        }

        public bool DeleteTimeSlot(int timeSlotId)
        {
            return _timeSlotRepository.Delete(timeSlotId);
        }

        public List<TimeSlotModel> GetAllTimeSlots()
        {
            return _timeSlotRepository.GetAll();
        }

        public TimeSlotModel GetTimeSlotById(int timeSlotId)
        {
            return _timeSlotRepository.GetById(timeSlotId);
        }

        // Phương thức cập nhật trạng thái khả dụng của khung giờ
        public bool UpdateAvailability(int timeSlotId, bool isAvailable)
        {
            return _timeSlotRepository.UpdateAvailability(timeSlotId, isAvailable);
        }
        public List<TimeSlotModel> GetTimeSlotsBySalonId(int salonId)
        {
            return _timeSlotRepository.GetBySalonId(salonId);
        }
        // Cập nhật phương thức: Lấy danh sách khung giờ hôm nay dựa trên salonId
        public List<TimeSlotModel> GetTimeSlotsForToday(int salonId)
        {
            return _timeSlotRepository.GetTimeSlotsForToday(salonId);
        }

        // Cập nhật phương thức: Lấy danh sách khung giờ ngày mai dựa trên salonId
        public List<TimeSlotModel> GetTimeSlotsForTomorrow(int salonId)
        {
            return _timeSlotRepository.GetTimeSlotsForTomorrow(salonId);
        }
    }
}
