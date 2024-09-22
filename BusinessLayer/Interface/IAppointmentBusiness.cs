using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IAppointmentBusiness
    {
        bool CreateAppointment(AppointmentModel appointment);     // Thêm mới cuộc hẹn
        bool UpdateAppointment(AppointmentModel appointment);     // Cập nhật thông tin cuộc hẹn
        bool DeleteAppointment(int appointmentId);                // Xóa cuộc hẹn theo ID
        List<AppointmentModel> GetAllAppointments();              // Lấy tất cả các cuộc hẹn
        AppointmentModel GetAppointmentById(int appointmentId);   // Lấy cuộc hẹn theo ID
        List<AppointmentModel> GetAppointmentsByCustomer(int customerId);  // Lấy cuộc hẹn của khách hàng
        List<AppointmentModel> GetAppointmentsBySalon(int salonId);        // Lấy cuộc hẹn của salon
        bool UpdateAppointmentStatus(int appointmentId, string status);    // Cập nhật trạng thái cuộc hẹn
    }
}
