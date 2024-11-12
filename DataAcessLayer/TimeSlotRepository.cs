using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public TimeSlotRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới khung giờ
        public bool Create(TimeSlotModel timeSlot)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_timeslot",
                    "@TimeSlot", timeSlot.TimeSlot,
                    "@IsAvailable", timeSlot.IsAvailable,
                    "@DateAvailable", timeSlot.DateAvailable,
                    "@SalonId", timeSlot.SalonId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating time slot: " + ex.Message);
            }
        }

        // Cập nhật khung giờ
        public bool Update(TimeSlotModel timeSlot)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_timeslot",
                    "@TimeSlotId", timeSlot.TimeSlotId,
                    "@TimeSlot", timeSlot.TimeSlot,
                    "@IsAvailable", timeSlot.IsAvailable,
                    "@DateAvailable", timeSlot.DateAvailable,
                    "@SalonId", timeSlot.SalonId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating time slot: " + ex.Message);
            }
        }

        // Xóa khung giờ
        public bool Delete(int timeSlotId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_timeslot",
                    "@TimeSlotId", timeSlotId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting time slot: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả các khung giờ
        public List<TimeSlotModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_timeslots");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<TimeSlotModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting time slot list: " + ex.Message);
            }
        }

        // Lấy khung giờ theo ID
        public TimeSlotModel GetById(int timeSlotId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_timeslot_by_id", "@TimeSlotId", timeSlotId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<TimeSlotModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting time slot by ID: " + ex.Message);
            }
        }

        // Cập nhật trạng thái khả dụng của khung giờ
        public bool UpdateAvailability(int timeSlotId, bool isAvailable)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_timeslot_availability",
                    "@TimeSlotId", timeSlotId,
                    "@IsAvailable", isAvailable);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating time slot availability: " + ex.Message);
            }
        }
        // Lấy danh sách các khung giờ theo SalonId
        public List<TimeSlotModel> GetBySalonId(int salonId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_timeslots_by_salonid", "@SalonId", salonId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<TimeSlotModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting time slots by salon ID: " + ex.Message);
            }
        }
        public List<TimeSlotModel> GetTimeSlotsForToday(int salonId)
        {
            string msgError = "";
            try
            {
                // Lấy ngày hôm nay
                var today = DateTime.Today.ToString("yyyy-MM-dd");

                // Truy vấn các khung giờ có DateAvailable là ngày hôm nay và thuộc salonId đã chọn
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_timeslots_by_salon_and_date",
                    "@SalonId", salonId,
                    "@DateAvailable", today);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<TimeSlotModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting time slots for today: " + ex.Message);
            }
        }
        public List<TimeSlotModel> GetTimeSlotsForTomorrow(int salonId)
        {
            string msgError = "";
            try
            {
                // Lấy ngày mai
                var tomorrow = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

                // Truy vấn các khung giờ có DateAvailable là ngày mai và thuộc salonId đã chọn
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_timeslots_by_salon_and_tomorrow",
                    "@SalonId", salonId,
                    "@DateAvailable", tomorrow);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<TimeSlotModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting time slots for tomorrow: " + ex.Message);
            }
        }
    }
}
