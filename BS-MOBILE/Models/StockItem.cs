using System.ComponentModel.DataAnnotations;

namespace BS_MOBILE.Models
{
    public class StockItem
    {
        public int Id { get; set; }

        [Required, StringLength(15, MinimumLength = 15)]
        public string IMEI { get; set; } = string.Empty;

        public decimal CostPrice { get; set; }

        public StockStatus Status { get; set; } = StockStatus.InStock;

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        //one phone has one sale item, one sale item has one phone
        public SaleItem? SaleItem { get; set; }
        public int MobileModelId { get; set; }
        public MobileModel? MobileModel { get; set; }
    }
}
