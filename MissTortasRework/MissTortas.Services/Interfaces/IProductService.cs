using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Services.Interfaces
{
    public interface IProductService
    {
        public Task<UnitDTO> CreateUnitAsync(UnitDTO unit);
        public Task<List<UnitDTO>> GetAllUnitsAsync();
        public Task<List<ProductDTO>> AllAsync();
        public Task<List<ProductCategoryDTO>> AllProductCategoryAsync();
        public Task<List<ProductCategoryDTO>> AllProductCategoryAsync(bool enabled);
        public Task<List<ProductCategoryDTO>> AllProductCategoryAsync(bool enabled, bool final);
        public Task<List<ProductDTO>> AllWithDetailAsync();
        public Task<ProductDTO> CreateProductAsync(ProductCreateDTO dto);
        public Task<ProductDTO?> GetProductByNameAsync(string name);
        public Task<SaleProductDTO> CreateSaleProductAsync(SaleProductCreateDTO dto);
        public Task<List<SaleProductDTO>> GetAllSaleProductsAsync();
        public Task<List<SaleProductDTO>> GetSaleProductsFromCategoryAsync(long categoryId);
        public Task<List<SaleProductDTO>> GetSaleProductsByNameAsync(string name);
        public Task<List<ProductDTO>> GetProductsFromCategoryAsync(long categoryId);
        public Task<SaleProduct> GetSaleProductEntityAsync(long id);
        public Task<SaleProductDTO> GetSaleProductAsync(long id);
        public Task<ProductCategoryDTO> CreateProductCategoryAsync(ProductCategoryCreateDTO dto);
        public Task DeleteProductCategory(long id);
        public Task<ProductDTO?> FindProduct(long id);
        public Task<ProductDTO> UpdateProductAsync(UpdateProductDTO dto);
        public Task UpdateProductCategoryAsync(UpdateProductCategoryDTO dto);
        public Task<SaleProductDTO> UpdateSaleProductAsync(UpdateSaleProductDTO dto);
    }
}
