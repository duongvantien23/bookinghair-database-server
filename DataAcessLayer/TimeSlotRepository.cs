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
                    "@IsAvailable", timeSlot.IsAvailable);

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
                    "@IsAvailable", timeSlot.IsAvailable);

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
    }
}
