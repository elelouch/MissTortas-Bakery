namespace MissTortas.Desktop.Services.DTO
{
    public class CreateSaleProductRequest
    {
        public long UnitId { get; set; }
        public string SaleProductName { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
        public decimal SaleQuantity { get; set; }
        public long CategoryId { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public string SaleImagePath { get; set; } = string.Empty;
    }
}
