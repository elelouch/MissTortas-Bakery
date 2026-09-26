using MissTortas.Domain.Products;
using MissTortas.Services.Repositories.DTO;
using System.Security.Cryptography.X509Certificates;

namespace MissTortas.Services.Repositories
{
    public interface IProductRepository : IRepositoryCrud<Product>
    {
        public Task InsertUnitAsync(Unit unit);
        public Task<List<Unit>> GetAllUnitsAsync();
        public Task<Unit?> FindUnitByIdAsync(long id);
        public Task<List<SaleProductDADto>> GetAllSaleProductsAsync();
        public Task<List<SaleProduct>> GetSaleProductsFromCategoryAsync(long categoryId);
        public Task<List<ProductDADto>> GetProductsFromCategoryAsync(long categoryId);
        public Task InsertProductCategoryAsync(ProductCategory productCategory);
        public Task<Product> GetWithDetailAsync(long id);
        public Task<ProductCategory?> FindProductCategoryAsync(long id);
        public Task InsertProductDetailAsync(ProductDetail productDetail);
        public Task InsertSaleProductAsync(SaleProduct saleProduct);
        public Task<SaleProduct?> GetSaleProductWithStockAsync(long id);
        public Task<SaleProductEntityDTO?> FindSaleProductDTOAsync(long id);
        public Task<SaleProduct?> FindSaleProductAsync(long id);
        public Task<Product?> FindProductByNameAsync(string name);
        public Task<List<ProductDADto>> GetAllWithDetailAsync();
        public Task<ProductCategory?> GetProductCategoryAsync(long id);
        public Task<ProductCategory?> GetProductCategoryByNameAsync(string name);
        public Task DeleteProductCategory(ProductCategory pc);
        public Task<List<ProductCategory>> GetAllProductCategoriesAsync();
    }
}
