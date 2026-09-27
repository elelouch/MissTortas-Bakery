namespace MissTortas.Desktop.Model
{
    public class SaleProduct
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public long CategoryId { get; set; }
        public long UnitId { get; set; }
        public bool Enabled { get; set; }
        public long StockProductId { get; set; }
        public List<string> FilePaths { get; set; } = [];
    }
}
