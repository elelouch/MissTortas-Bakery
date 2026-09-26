namespace Misstortas.Frontend.Models
{
    public class SaleProduct
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
        public decimal Quantity { get; set; }
        public List<string> FilePaths { get; set; } = [];
        public bool AllowDecimalAsk { get; set; }
    }
}