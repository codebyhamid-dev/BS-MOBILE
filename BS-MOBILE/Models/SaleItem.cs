namespace BS_MOBILE.Models
{
    public class SaleItem
    {
         public int Id { get; set; }

        public int SaleId { get; set; }
        public Sale? Sale { get; set; }

        public int StockItemId { get; set; }
        public StockItem? StockItem { get; set; }

        public decimal SalePrice { get; set; }
    }
}
