using MissTortas.Services.DTO.Products;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Mappers
{
    public class PresentationProductMapper : IPresentationProductMapper
    {
        public SaleProductCreateDTO MapCreateSaleProductRequestToDTO(CreateSaleProductRequest request)
        {
            return new SaleProductCreateDTO
            {
                Name = request.SaleProductName,
                SalePrice = request.SalePrice,
                Quantity = request.SaleQuantity,
                CategoryId = request.CategoryId,
                UnitId = request.UnitId,
                SaleDescription = request.SaleDescription,
                SaleImagePath = request.SaleImagePath,
                IsAvailable = false
            };
        }
        public SaleProductResponse MapDtoToResponse(SaleProductDTO dto, List<string> filePaths)
        {
            return new SaleProductResponse
            {
                Id = dto.Id,
                SalePrice = dto.Price,
                Description = dto.Description,
                AllowDecimalAsk = dto.AllowDecimalAsk,
                Quantity = dto.Quantity,
                Name = dto.Name,
                StockProductId = dto.StockProductId,
                Enabled = dto.Enabled,
                UnitId = dto.UnitId,
                CategoryId = dto.CategoryId,
                FilePaths = filePaths
            };
        }
        public List<SaleProductResponse> MapDtoToResponse(IEnumerable<SaleProductDTO> dtos)
        {
            return [.. dtos.Select(dto => MapDtoToResponse(dto, []))];
        }

        public List<SaleProductResponse> MapDtoToResponse(IEnumerable<SaleProductDTO> dtos, Dictionary<long, List<string>> filePaths)
        {
            return [.. dtos.Select(dto =>
            {
                var filePath = filePaths.TryGetValue(dto.Id, out var sape);
                var a = MapDtoToResponse(dto, sape ?? []);
                return a;
            })];
        }

        public UpdateSaleProductDTO MapUpdateRequestToDto(long saleProductId, UpdateSaleProductRequest request)
        {
            return new UpdateSaleProductDTO
            {
                SaleProductId = saleProductId,
                Name = request.Name,
                Description = request.Description,
                Quantity = request.QuantityAvailable,
                Price = request.Price
            };
        }

    }
}
