using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using static DataModel.AppointmentModel;

namespace DataAcessLayer
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public AppointmentRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới cuộc hẹn
        public bool Create(AppointmentModel appointment)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_appointment",
                    "@CustomerId", appointment.CustomerId,
                    "@SalonId", appointment.SalonId,
                    "@HairstylistId", appointment.HairstylistId,
                    "@ServiceId", appointment.ServiceId,
                    "@TimeSlotId", appointment.TimeSlotId,  
                    "@AppointmentDate", appointment.AppointmentDate,
                    "@Notes", appointment.Notes,
                    "@StatuId", appointment.StatusId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating appointment: " + ex.Message);
            }
        }

        // Cập nhật cuộc hẹn
        public bool Update(AppointmentModel appointment)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_appointment",
                    "@AppointmentId", appointment.AppointmentId,
                    "@CustomerId", appointment.CustomerId,
                    "@SalonId", appointment.SalonId,
                    "@HairstylistId", appointment.HairstylistId,
                    "@ServiceId", appointment.ServiceId,
                    "@TimeSlotId", appointment.TimeSlotId,  
                    "@AppointmentDate", appointment.AppointmentDate,
                    "@Notes", appointment.Notes,
                    "@StatusId", appointment.StatusId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating appointment: " + ex.Message);
            }
        }

        // Xóa cuộc hẹn
        public bool Delete(int appointmentId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_appointment",
                    "@AppointmentId", appointmentId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting appointment: " + ex.Message);
            }
        }

        // Lấy tất cả các cuộc hẹn
        public List<AppointmentModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_appointments");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<AppointmentModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting appointments list: " + ex.Message);
            }
        }

        // Lấy cuộc hẹn theo ID
        public AppointmentModel GetById(int appointmentId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_appointment_by_id", "@AppointmentId", appointmentId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<AppointmentModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting appointment by ID: " + ex.Message);
            }
        }

        // Lấy các cuộc hẹn theo khách hàng
        public List<AppointmentModel> GetByCustomer(int customerId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_appointments_by_customer", "@CustomerId", customerId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<AppointmentModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting appointments by customer: " + ex.Message);
            }
        }

        // Lấy các cuộc hẹn theo salon
        public List<AppointmentModel> GetBySalon(int salonId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_appointments_by_salon", "@SalonId", salonId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<AppointmentModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting appointments by salon: " + ex.Message);
            }
        }
        public bool CreateAppointmentForUser(AppointmentUserModel appointmentUser)
        {
            string msgError = "";
            try
            {
                string listJsonCustomer = Newtonsoft.Json.JsonConvert.SerializeObject(appointmentUser.ListJsonCustomer);

                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_appointment_for_user",
                    "@CustomerId", appointmentUser.CustomerId,
                    "@SalonId", appointmentUser.SalonId,
                    "@HairstylistId", appointmentUser.HairstylistId,
                    "@ServiceId", appointmentUser.ServiceId,
                    "@TimeSlotId", appointmentUser.TimeSlotId,
                    "@AppointmentDate", appointmentUser.AppointmentDate,
                    "@Notes", appointmentUser.Notes,
                    "@StatusId", appointmentUser.StatusId,
                    "@ListJsonCustomer", listJsonCustomer);

                if (!string.IsNullOrEmpty(msgError))
                {
                    Console.WriteLine("Stored Procedure Error: " + msgError);
                    throw new Exception(msgError);
                }

                if (result == null || string.IsNullOrEmpty(result.ToString()))
                {
                    Console.WriteLine("Stored Procedure returned no result.");
                    throw new Exception("Stored Procedure returned no result.");
                }

                Console.WriteLine("Result: " + result.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating appointment for user: " + ex.Message);
                throw new Exception("Error creating appointment for user: " + ex.Message);
            }
        }
    }
}
