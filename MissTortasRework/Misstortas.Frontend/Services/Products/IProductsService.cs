using Misstortas.Frontend.Models;

namespace Misstortas.Frontend.Services.Products
{
    public interface IProductsService
    {
        public Task<Category[]> GetCategoriesAsync();
        public Task<SaleProduct[]> GetSaleProductsAsync(long categoryId);
        public Task<SaleProduct[]> SearchSaleProductsAsync(string searchTerm);
    }
}
