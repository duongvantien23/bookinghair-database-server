using System;

namespace DataModel
{
    public class TimeSlotModel
    {
        public int TimeSlotId { get; set; }
        public string TimeSlot { get; set; }
        public bool IsAvailable { get; set; }
        public int SalonId { get; set; }
        public DateTime DateAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TimeSlotModel()
        {
            IsAvailable = true;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            DateAvailable = DateTime.Now; // Đặt giá trị mặc định cho DateAvailable là ngày hiện tại
        }
    }
}
