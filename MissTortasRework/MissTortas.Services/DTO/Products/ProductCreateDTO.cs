namespace MissTortas.Services.DTO.Products
{
    public class ProductCreateDTO
    {
        public long UnitId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public long CategoryId { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
    }
}
