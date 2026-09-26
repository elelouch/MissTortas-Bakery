using MissTortas.Services.DTO.Products;

namespace MissTortas.View.DTO.Products
{
    public class SaleProductResponse
    {
        public long Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long StockProductId { get; set; }
        public List<string> FilePaths { get; set; } = [];
        public bool AllowDecimalAsk { get; set; }
    }
}
