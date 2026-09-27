namespace MissTortas.Services.DTO.Products
{
    public class UpdateSaleProductDTO
    {
        public long SaleProductId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public bool? Enabled { get; set; }
    }
}
