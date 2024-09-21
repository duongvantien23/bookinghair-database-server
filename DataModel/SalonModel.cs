using System;

namespace DataModel
{
    public class SalonModel
    {
        public int SalonId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string NameSalon { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ImageSalon { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Constructor để khởi tạo giá trị mặc định cho CreatedAt và UpdatedAt
        public SalonModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
