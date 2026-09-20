namespace MissTortas.Domain.Products
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ProductDetail ProductDetail { get; set; } = default!;
        public long ProductDetailId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; } = default!;
        public long ProductCategoryId { get; set; }
        public decimal Quantity { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
        public required Unit Unit { get; set; }
        public long UnitId { get; set; }
        public bool Enabled { get; set; }
        public SaleProduct? SaleProduct { get; set; }
        public long? SaleProductId { get; set; }
    }
}
