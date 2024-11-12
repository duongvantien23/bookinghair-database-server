using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAcessLayer
{
    public class AppointmentStatusRepository : IAppointmentStatusRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public AppointmentStatusRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm trạng thái cuộc hẹn mới
        public bool Create(AppointmentStatusModel status)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_appointment_status",
                    "@StatusName", status.StatusName);

                HandleProcedureError(msgError, result);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating appointment status: " + ex.Message, ex);
            }
        }

        // Cập nhật trạng thái cuộc hẹn
        public bool Update(AppointmentStatusModel status)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_appointment_status",
                    "@StatusId", status.StatusId,
                    "@StatusName", status.StatusName);

                HandleProcedureError(msgError, result);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating appointment status: " + ex.Message, ex);
            }
        }

        // Xóa trạng thái cuộc hẹn
        public bool Delete(int statusId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_appointment_status",
                    "@StatusId", statusId);

                HandleProcedureError(msgError, result);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting appointment status: " + ex.Message, ex);
            }
        }

        // Lấy danh sách tất cả trạng thái cuộc hẹn
        public List<AppointmentStatusModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_appointment_statuses");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception("Error retrieving appointment statuses: " + msgError);
                }

                return dt.ConvertTo<AppointmentStatusModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting appointment statuses list: " + ex.Message, ex);
            }
        }

        // Lấy thông tin trạng thái cuộc hẹn theo ID
        public AppointmentStatusModel GetById(int statusId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_appointment_status_by_id", "@StatusId", statusId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception("Error retrieving appointment status by ID: " + msgError);
                }

                return dt.ConvertTo<AppointmentStatusModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting appointment status by ID: " + ex.Message, ex);
            }
        }

        // Phương thức xử lý lỗi chung từ stored procedure
        private void HandleProcedureError(string msgError, object result)
        {
            if (!string.IsNullOrEmpty(msgError))
            {
                throw new Exception("Stored Procedure Error: " + msgError);
            }

            if (result != null && !string.IsNullOrEmpty(result.ToString()))
            {
                throw new Exception("Stored Procedure returned unexpected result: " + result);
            }
        }
    }
}
