using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Repositories.DTO
{
    public class SaleProductDADto
    {
        public long Id { get; set; }
        public long StockProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal SaleQuantity { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal SalePrice { get; set; }
        public long UnitId { get; set; }
        public bool Enabled { get; set; }
        public bool IsAvailable { get; set; }
        public long CategoryId { get; set; }
    }
}
