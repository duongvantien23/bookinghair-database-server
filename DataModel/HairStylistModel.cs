using System;

namespace DataModel
{
    public class HairStylistModel
    {
        public int HairstylistId { get; set; }
        public int SalonId { get; set; }
        public string NameStylist { get; set; }
        public string Phone { get; set; }
        public string MainImage { get; set; }
        public decimal Salary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public HairStylistModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
