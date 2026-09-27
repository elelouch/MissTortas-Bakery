using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.DTO;

namespace MissTortas.Desktop.Services
{
    public static class ProductMapper
    {
        public static CreateSaleProductRequest ToCreateRequest(this SaleProduct saleProduct)
        {
            return new CreateSaleProductRequest
            {
                UnitId = saleProduct.UnitId,
                SaleProductName = saleProduct.Name,
                SalePrice = saleProduct.SalePrice,
                SaleQuantity = saleProduct.Quantity,
                CategoryId = saleProduct.CategoryId,
                SaleDescription = saleProduct.Description,
                SaleImagePath = saleProduct.FilePaths.FirstOrDefault() ?? string.Empty
            };
        }

        /// <summary>
        /// Maps a CreateSaleProductRequest to a SaleProduct
        /// </summary>
        public static SaleProduct ToSaleProduct(this CreateSaleProductRequest request)
        {
            return new SaleProduct
            {
                UnitId = request.UnitId,
                Name = request.SaleProductName,
                SalePrice = request.SalePrice,
                Quantity = request.SaleQuantity,
                CategoryId = request.CategoryId,
                Description = request.SaleDescription,
                //FilePaths = string.IsNullOrEmpty(request.SaleImagePath)
                //    ? []
                //    : [request.SaleImagePath]
            };
        }
        public static UpdateSaleProductRequest ToUpdateRequest(this SaleProduct saleProduct)
        {
            return new UpdateSaleProductRequest
            {
                Name = saleProduct.Name,
                Description = saleProduct.Description,
                QuantityAvailable = saleProduct.Quantity,
                Price = saleProduct.SalePrice
            };
        }

    }
}
