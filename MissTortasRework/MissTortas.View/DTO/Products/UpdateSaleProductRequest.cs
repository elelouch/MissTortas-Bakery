using Microsoft.AspNetCore.Mvc;

namespace MissTortas.View.DTO.Products
{
    public class UpdateSaleProductRequest
    {
        public bool Enabled { get; set; }
        public string? SaleProductName { get; set; }
        public string? SaleDescription { get; set; }
        public decimal? SaleQuantity { get; set; }
        public decimal? SalePrice { get; set; }
        public long? UnitId { get; set; }
    }
}
