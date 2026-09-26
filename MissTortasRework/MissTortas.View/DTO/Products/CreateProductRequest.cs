namespace MissTortas.View.DTO.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long CategoryId { get; set; }
        public decimal Quantity { get; set; }
        public long UnitId { get; set; }
    }
}
