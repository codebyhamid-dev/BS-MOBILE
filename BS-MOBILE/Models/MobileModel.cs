using System.ComponentModel.DataAnnotations;

namespace BS_MOBILE.Models
{
    public class MobileModel
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Storage { get; set; }      // e.g. 128GB

        [StringLength(50)]
        public string? Color { get; set; }

        [StringLength(300)]
        public string? ImagePath { get; set; }    // uploads/mobiles/xyz.jpg

        public decimal SalePrice { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
    }
}
