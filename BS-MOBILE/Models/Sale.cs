using System.ComponentModel.DataAnnotations;

namespace BS_MOBILE.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string InvoiceNo { get; set; } = string.Empty;

        public DateTime SaleDate { get; set; } = DateTime.Now;

        [Required, StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? CustomerPhone { get; set; }

        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }

        public string SoldById { get; set; } = string.Empty;
        public ApplicationUser? SoldBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
