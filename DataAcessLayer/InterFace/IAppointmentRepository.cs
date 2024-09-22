using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public interface IAppointmentRepository
    {
        bool Create(AppointmentModel appointment);         // Thêm mới cuộc hẹn
        bool Update(AppointmentModel appointment);         // Cập nhật thông tin cuộc hẹn
        bool Delete(int appointmentId);                    // Xóa cuộc hẹn theo ID
        List<AppointmentModel> GetAll();                   // Lấy danh sách tất cả các cuộc hẹn
        AppointmentModel GetById(int appointmentId);       // Lấy thông tin cuộc hẹn theo ID
        List<AppointmentModel> GetByCustomer(int customerId);  // Lấy danh sách cuộc hẹn của khách hàng
        List<AppointmentModel> GetBySalon(int salonId);        // Lấy danh sách cuộc hẹn của salon
        bool UpdateStatus(int appointmentId, string status);   // Cập nhật trạng thái cuộc hẹn
    }
}
