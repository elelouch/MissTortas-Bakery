using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductUnit>> GetUnitsAsync();
        public Task<Product> ModifyProductAsync(Product product);
        public Task<List<ProductCategory>> GetCategoriesAsync();
        public Task<List<ProductCategory>> GetCategoriesAsync(bool enabled);
        public Task<List<ProductCategory>> GetCategoriesAsync(bool enabled, bool final);
        public Task<List<Product>> GetProductsFromCategoryAsync(long id);
        public Task<List<SaleProduct>> GetSaleProductsFromCategoryAsync(long id);
        public Task<ProductCategory?> CreateProductCategoryAsync(ProductCategory pc);
        public Task UpdateProductCategoryAsync(ProductCategory pc);
        public Task<Product> CreateProductAsync(Product pc);
        public Task<SaleProduct> ModifySaleProductAsync(SaleProduct sp);
        public Task<SaleProduct> ModifySaleProductAsync(SaleProduct sp, Dictionary<string, string> files);
        public Task<SaleProduct> CreateSaleProductAsync(SaleProduct sp);
        public Task<SaleProduct> CreateSaleProductAsync(SaleProduct sp, Dictionary<string, string> files);
        public Task<List<Product>> GetAllProductsAsync();
        public Task<List<SaleProduct>> GetAllSaleProductsAsync();
    }
}
