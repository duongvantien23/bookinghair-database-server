using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DataAcessLayer.InterFace;
using DataModel;
using Microsoft.Extensions.Options;

namespace DataAccessLayer
{
    public class EmailRepository : IEmailRepository
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailRepository(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendAppointmentSuccessEmailAsync(
            string email, string customerName, string cityName, string districtName,
            string salonName, string hairstylistName, string serviceName, DateTime dateAvailable,
            string timeSlot, string phone, string notes, DateTime appointmentDate)
        {
            using (var smtpClient = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                    Subject = "Xác nhận đặt lịch hẹn thành công",
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);

                // Nội dung HTML cho email, thêm thông tin ngày đặt lịch AppointmentDate
                var body = $@"
                    <h2>Chào {customerName},</h2>
                    <p>Đây là thông tin chi tiết về lịch hẹn của bạn:</p>
                    <ul>
                        <li><strong>Thành phố:</strong> {cityName}</li>
                        <li><strong>Quận/Huyện:</strong> {districtName}</li>
                        <li><strong>Salon:</strong> {salonName}</li>
                        <li><strong>Thợ cắt tóc:</strong> {hairstylistName}</li>
                        <li><strong>Dịch vụ:</strong> {serviceName}</li>
                        <li><strong>Ngày đặt lịch:</strong> {appointmentDate:dd/MM/yyyy}</li>
                        <li><strong>Ngày hẹn:</strong> {dateAvailable:dd/MM/yyyy}</li>
                        <li><strong>Thời gian:</strong> {timeSlot}</li>
                        <li><strong>Họ và Tên khách hàng:</strong> {customerName}</li>
                        <li><strong>Email:</strong> {email}</li>
                        <li><strong>Số điện thoại:</strong> {phone}</li>
                        {(string.IsNullOrEmpty(notes) ? "" : $"<li><strong>Ghi chú:</strong> {notes}</li>")}
                    </ul>
                    <p>Cảm ơn bạn đã đặt lịch với chúng tôi!</p>
                    <p>Trân trọng,</p>
                    <p>Đội ngũ Booking Hair</p>";

                mailMessage.Body = body;

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to send email: " + ex.Message);
                    throw new Exception("Error sending email: " + ex.Message);
                }
            }
        }
    }
}
