using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class WorkingHourRepository : IWorkingHourRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public WorkingHourRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới giờ làm việc
        public bool Create(WorkingHourModel workingHour)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_working_hour",
                    "@HairstylistId", workingHour.HairstylistId,
                    "@WorkDay", workingHour.WorkDay,
                    "@StartTime", workingHour.StartTime,
                    "@EndTime", workingHour.EndTime);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating working hour: " + ex.Message);
            }
        }

        // Cập nhật giờ làm việc
        public bool Update(WorkingHourModel workingHour)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_working_hour",
                    "@WorkingHourId", workingHour.WorkingHourId,
                    "@HairstylistId", workingHour.HairstylistId,
                    "@WorkDay", workingHour.WorkDay,
                    "@StartTime", workingHour.StartTime,
                    "@EndTime", workingHour.EndTime);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating working hour: " + ex.Message);
            }
        }

        // Xóa giờ làm việc
        public bool Delete(int workingHourId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_working_hour",
                    "@WorkingHourId", workingHourId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting working hour: " + ex.Message);
            }
        }

        // Lấy giờ làm việc theo ID
        public WorkingHourModel GetById(int workingHourId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_working_hour_by_id", "@WorkingHourId", workingHourId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<WorkingHourModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting working hour by ID: " + ex.Message);
            }
        }

        // Lấy giờ làm việc theo thợ cắt tóc
        public List<WorkingHourModel> GetByHairstylist(int hairstylistId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_working_hours_by_hairstylist", "@HairstylistId", hairstylistId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<WorkingHourModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting working hours by hairstylist: " + ex.Message);
            }
        }

        // Lấy giờ làm việc theo ngày
        public List<WorkingHourModel> GetByDate(DateTime workDay)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_working_hours_by_date", "@WorkDay", workDay);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<WorkingHourModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting working hours by date: " + ex.Message);
            }
        }

        // Kiểm tra khả dụng
        public bool CheckAvailability(int hairstylistId, DateTime workDay, TimeSpan startTime, TimeSpan endTime)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_check_hairstylist_availability",
                    "@HairstylistId", hairstylistId,
                    "@WorkDay", workDay,
                    "@StartTime", startTime,
                    "@EndTime", endTime);

                if (!string.IsNullOrEmpty(msgError) || result == null || Convert.ToInt32(result) == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking availability: " + ex.Message);
            }
        }
    }
}
