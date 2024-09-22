using System;

namespace DataModel
{
    public class PromotionModel
    {
        public int PromotionId { get; set; }
        public string NamePromo { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public PromotionModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
