namespace MissTortas.Services.DTO.Products
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public long UnitId { get; set; }
        public decimal Quantity { get; set; }
        public bool Enabled { get; set; }
    }
}