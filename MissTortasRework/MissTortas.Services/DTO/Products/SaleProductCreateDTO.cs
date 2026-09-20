namespace MissTortas.Services.DTO.Products
{
    public class SaleProductCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
        public decimal Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public long CategoryId { get; set; }
        public long UnitId { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public string SaleImagePath { get; set; } = string.Empty;
    }
}
