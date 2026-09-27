using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.Shared;

namespace MissTortas.Desktop.Services.ProductService
{
    public class ProductService : IProductService
    {
        public MissTortasHttpClient httpClient;
        public ProductService(MissTortasHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Product> CreateProductAsync(Product pc)
        {
            var ret = await httpClient.PostAsync<Product>("products", pc);
            return ret!;
        }

        public async Task<ProductCategory?> CreateProductCategoryAsync(ProductCategory pc)
        {
            var ret = await httpClient.PostAsync<ProductCategory>("categories", pc);
            return ret;
        }

        public async Task<List<ProductCategory>> GetCategoriesAsync(bool enabled, bool final)
        {
            var categories = await httpClient.GetAsync<List<ProductCategory>>($"categories?enabled={enabled}&final={final}");
            return categories ?? [];
        }

        public async Task<Dictionary<long, ProductCategory>> GetProductCategoryDictionaryAsync(ProductCategory pc)
        {
            var categories = await httpClient.GetAsync<List<ProductCategory>>("categories");
            if (categories == null)
            {
                throw new InvalidOperationException("Categories can not be null");
            }
            return categories.ToDictionary(c => c.ProductCategoryId, c => c);
        }

        public async Task<List<Product>> GetProductsFromCategoryAsync(long categoryId)
        {
            var products = await httpClient.GetAsync<List<Product>>($"categories/{categoryId}/products");
            return products ?? [];
        }

        public async Task<Product> ModifyProductAsync(Product product)
        {
            var ret = await httpClient.PutAsync<Product>($"products/{product.Id}", product);
            return ret!;
        }

        public async Task UpdateProductCategoryAsync(ProductCategory pc)
        {
            await httpClient.PutAsync<object>($"categories/{pc.ProductCategoryId}", pc);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await httpClient.GetAsync<List<Product>>("products");
            return products!;
        }

        public Task<List<ProductCategory>> GetCategoriesAsync()
        {
            return GetCategoriesAsync(true, false);
        }

        public Task<List<ProductCategory>> GetCategoriesAsync(bool enabled)
        {
            return GetCategoriesAsync(enabled, false);
        }

        public async Task<List<SaleProduct>> GetSaleProductsFromCategoryAsync(long id)
        {
            var saleProducts = await httpClient.GetAsync<List<SaleProduct>>($"categories/{id}/saleproducts");
            return saleProducts!;
        }

        public async Task<List<SaleProduct>> GetAllSaleProductsAsync()
        {
            var ret = await httpClient.GetAsync<List<SaleProduct>>($"saleproducts");
            return ret!;
        }

        public Task<SaleProduct> CreateSaleProductAsync(SaleProduct sp)
        {
            return CreateSaleProductAsync(sp, []);
        }

        public async Task<SaleProduct> CreateSaleProductAsync(SaleProduct sp, Dictionary<string, string> files)
        {
            var body = ProductMapper.ToCreateRequest(sp);
            List<(Stream stream, string fileName)> fileStreams = [];

            try
            {
                foreach (var file in files)
                {
                    string fileName = file.Key;      // File name
                    string filePath = file.Value;    // Path to file
                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    fileStreams.Add((stream, fileName));
                }
                var ret = await httpClient.PostAsFormAsync<SaleProduct>("saleproducts", body, fileStreams);
                return ret!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create sale product: {ex.Message}", "Error");
                throw;
            }
            finally
            {
                // Close all streams
                foreach (var (stream, fileName) in fileStreams)
                {
                    try
                    {
                        stream?.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error closing stream for {fileName}: {ex.Message}", "Warning");
                    }
                }
            }
        }

        public async Task<SaleProduct> ModifySaleProductAsync(SaleProduct sp)
        {
            var body = ProductMapper.ToUpdateRequest(sp);
            var ret = await httpClient.PutAsync<SaleProduct>($"saleproducts/{sp.Id}", body);
            return ret!;
        }

        public async Task<SaleProduct> CreateSaleProductPutAsync(SaleProduct sp, Dictionary<string, string> files)
        {
            var body = ProductMapper.ToCreateRequest(sp);
            List<(Stream stream, string fileName)> fileStreams = [];

            try
            {
                foreach (var file in files)
                {
                    string fileName = file.Key;      // File name
                    string filePath = file.Value;    // Path to file
                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    fileStreams.Add((stream, fileName));
                }
                var ret = await httpClient.PostAsFormAsync<SaleProduct>("saleproducts", body, fileStreams);
                return ret!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create sale product: {ex.Message}", "Error");
                throw;
            }
            finally
            {
                // Close all streams
                foreach (var (stream, fileName) in fileStreams)
                {
                    try
                    {
                        stream?.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error closing stream for {fileName}: {ex.Message}", "Warning");
                    }
                }
            }
        }

        public async Task<SaleProduct> ModifySaleProductAsync(SaleProduct sp, Dictionary<string, string> files)
        {
            var body = ProductMapper.ToCreateRequest(sp);
            List<(Stream stream, string fileName)> fileStreams = [];
            try
            {
                foreach (var file in files)
                {
                    string fileName = file.Key;      // File name
                    string filePath = file.Value;    // Path to file
                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    fileStreams.Add((stream, fileName));
                }
                var ret = await httpClient.PutAsFormAsync<SaleProduct>($"saleproducts/test/{sp.Id}", body, fileStreams);
                return ret!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create sale product: {ex.Message}", "Error");
                throw;
            }
            finally
            {
                // Close all streams
                foreach (var (stream, fileName) in fileStreams)
                {
                    try
                    {
                        stream?.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error closing stream for {fileName}: {ex.Message}", "Warning");
                    }
                }
            }
        }

        public async Task<List<ProductUnit>> GetUnitsAsync()
        {
            var units = await httpClient.GetAsync<List<ProductUnit>>("products/units");
            return units!;
        }
    }
}
