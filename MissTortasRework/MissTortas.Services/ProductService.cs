using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping.Interfaces;
using MissTortas.Services.Repositories;

namespace MissTortas.Services
{
    public class ProductService(
        IProductRepository productRepository,
        IProductMapper productMapper
        ) : IProductService
    {
        public async Task<ProductDTO?> GetProductByNameAsync(string name)
        {
            var product = await productRepository.FindProductByNameAsync(name);
            if (product is not null)
            {
                return productMapper.ProductToDTO(product);
            }
            return null;
        }

        private async Task<Product> CreateProductEntityAsync(ProductCreateDTO dto)
        {
            var productDetail = new ProductDetail { Description = dto.Description };
            await productRepository.InsertProductDetailAsync(productDetail);
            await productRepository.SaveChangesAsync();
            var result = await productRepository.FindProductByNameAsync(dto.Name);
            if (result is not null)
            {
                throw new AlreadyCreatedException("Product with that name already created");
            }
            var productCategory = await productRepository.FindProductCategoryAsync(dto.CategoryId) ?? throw new EntityNotFoundException("Category not found", "CATNF0");
            if (!productCategory.IsFinal)
            {
                throw new ChildAppendException("Cannot append a product on a Category that is not final.");
            }
            if (!productCategory.Enabled)
            {
                throw new ChildAppendException("Cannot append a product on a Category that is disabled.");
            }

            var unit = await productRepository.FindUnitByIdAsync(dto.UnitId) ?? throw new UnitNotFoundException("Unit not found.");
            if(dto.Quantity < 0)
            {
                throw new QuantityException("Negative quantities are not valid.");
            }

            if(Math.Round(dto.Quantity) != dto.Quantity && unit.TreatAsInteger)
            {
                throw new QuantityException("Quantity must be integer.");
            }

            var product = new Product
            {
                Unit = unit,
                Name = dto.Name,
                ProductDetail = productDetail,
                ProductCategory = productCategory,
                Quantity = dto.Quantity,
                Enabled = true
            };
            await productRepository.InsertAsync(product);
            await productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductCreateDTO dto)
        {
            var product = await CreateProductEntityAsync(dto);
            return productMapper.ProductToDTO(product);
        }

        public async Task<List<ProductDTO>> AllAsync()
        {
            var products = await productRepository.GetAllAsync();
            return productMapper.ProductToDTO(products);
        }

        public async Task<List<ProductDTO>> AllWithDetailAsync()
        {
            var products = await productRepository.GetAllWithDetailAsync();
            return productMapper.ProductToDTO(products);
        }

        public async Task<SaleProductDTO> CreateSaleProductAsync(SaleProductCreateDTO dto)
        {
            var productCreateDTO = new ProductCreateDTO
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Description = dto.SaleDescription,
                UnitId = dto.UnitId,
                Quantity = dto.Quantity
            };
            var stockProduct = await CreateProductEntityAsync(productCreateDTO);
            var saleProduct = new SaleProduct
            {
                SalePrice = dto.SalePrice,
                IsAvailable = dto.IsAvailable,
                ProductId = stockProduct.ProductId,
                SaleQuantity = dto.Quantity
            };
            await productRepository.InsertSaleProductAsync(saleProduct);
            await productRepository.SaveChangesAsync();
            return productMapper.SaleProductToDTO(saleProduct);
        }

        public async Task<ProductCategoryDTO> CreateProductCategoryAsync(ProductCategoryCreateDTO dto)
        {
            ProductCategory? parent = null;
            if (dto.ParentId is not null)
            {
                var parentId = dto.ParentId.Value;
                parent = await productRepository.FindProductCategoryAsync(parentId);
            }
            if (parent is not null && parent.IsFinal)
            {
                throw new ParentIsFinalException("Parent is final, cannot append another category");
            }
            if(string.IsNullOrEmpty(dto.Name) || dto.Name.Length < 3 || dto.Name.Length > 256)
            {
                throw new InvalidOperationException("Name must have a length between 3 and 255 inclusive.");
            }
            if ((await productRepository.GetProductCategoryByNameAsync(dto.Name)) != null)
            {
                throw new AlreadyCreatedException("Name already in use.");
            }
            var productCategory = new ProductCategory
            {
                Name = dto.Name,
                ParentId = parent?.ProductCategoryId,
                Children = [],
                Products = [],
                IsFinal = dto.IsFinal,
                Enabled = true
            };

            await productRepository.InsertProductCategoryAsync(productCategory);
            await productRepository.SaveChangesAsync();
            return productMapper.CategoryToDTO(productCategory);
        }

        public async Task DeleteProductCategory(long id)
        {
            var pc = await productRepository.GetProductCategoryAsync(id) ?? throw new ProductCategoryNotFoundException("Product category not found");
            await productRepository.DeleteProductCategory(pc);
            await productRepository.SaveChangesAsync();
        }

        public async Task<ProductDTO?> FindProduct(long id)
        {
            var product = await productRepository.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            return productMapper.ProductToDTO(product);
        }

        public async Task<SaleProduct> GetSaleProductEntityAsync(long id)
        {
            var sp = await productRepository.FindSaleProductAsync(id) ?? throw new SaleProductNotFoundException("Product for sale not found");
            return sp;
        }

        public async Task<ProductDTO> UpdateProductAsync(UpdateProductDTO dto)
        {
            var product = await productRepository.GetWithDetailAsync(dto.ProductId);
            if (dto.Description is not null)
            {
                product.ProductDetail.Description = dto.Description;
            }
            if (dto.Quantity is decimal quantity)
            {
                var qtyIsInteger = Math.Floor(quantity) == quantity;
                if (product.Unit.TreatAsInteger && !qtyIsInteger)
                {
                    throw new AskQuantityException("Quantity is not valid, try an integer quantity.");
                }
                product.Quantity = quantity;
            }
            if (dto.CategoryId is long categoryId)
            {
                var category = await productRepository.FindProductCategoryAsync(categoryId);
                if (category is not null)
                {
                    product.ProductCategory = category;
                }
            }
            if(dto.Enabled is bool enabled)
            {
                product.Enabled = enabled;
            }
            productRepository.Update(product);
            await productRepository.SaveChangesAsync();
            return productMapper.ProductToDTO(product);
        }

        public async Task<List<SaleProductDTO>> GetSaleProductsFromCategoryAsync(long categoryId)
        {
            var saleProducts = await productRepository.GetSaleProductsFromCategoryAsync(categoryId);
            return productMapper.SaleProductToDTO(saleProducts);
        }

        public async Task<SaleProductDTO> UpdateSaleProductAsync(UpdateSaleProductDTO dto)
        {
            var saleProduct = await productRepository.GetSaleProductWithStockAsync(dto.SaleProductId) ?? throw new EntityNotFoundException($"Sale Product not found. ID: {dto.SaleProductId}");
            var stockQuantity = saleProduct.Product.Quantity;
            if (dto.Quantity is not null && stockQuantity < dto.Quantity)
            {
                throw new InvalidOperationException($"Cannot place more quantity than available. asked: {dto.Quantity}, available: {stockQuantity}");
            }
            if (dto.Quantity is decimal qty)
            {
                saleProduct.SaleQuantity = qty;
            }
            if (dto.Price is decimal price)
            {
                saleProduct.SalePrice = price;
            }
            if (dto.Name is not null)
            {
                saleProduct.Product.Name = dto.Name;
            }
            if (dto.Description is not null)
            {
                saleProduct.Product.ProductDetail.Description = dto.Description;
            }
            await productRepository.SaveChangesAsync();
            return productMapper.SaleProductToDTO(saleProduct);
        }

        public async Task<SaleProductDTO> GetSaleProductAsync(long id)
        {
            var saleProductDTO = await productRepository.FindSaleProductDTOAsync(id) ?? throw new SaleProductNotFoundException($"Sale product not found. Id: {id}");
            return new SaleProductDTO
            {
                Id = saleProductDTO.SaleProductId
            };
        }

        public async Task<List<ProductDTO>> GetProductsFromCategoryAsync(long categoryId)
        {
            var pc = await productRepository.FindProductCategoryAsync(categoryId) ?? throw new ProductCategoryNotFoundException("Category not found.");
            if(!pc.IsFinal)
            {
                throw new ChildAppendException("Category is final, can not have child products");
            }
            var products = await productRepository.GetProductsFromCategoryAsync(categoryId);
            var ret = productMapper.ProductToDTO(products);
            return ret;
        }

        public async Task UpdateProductCategoryAsync(UpdateProductCategoryDTO dto)
        {
            var pc = await productRepository.FindProductCategoryAsync(dto.ProductCategoryId) ?? throw new ProductCategoryNotFoundException("Product category not found");
            if (dto.ParentId is long newParentId)
            {
                if (await IsDescendant(newParentId, dto.ProductCategoryId))
                {
                    throw new ChildAppendException("Cannot append a parent to a child.");
                }
                pc.ParentId = newParentId;
            }
            if (string.IsNullOrEmpty(dto.Name) || dto.Name.Length < 3 || dto.Name.Length > 256)
            {
                throw new InvalidOperationException("Name must have a length between 3 and 256");
            }
            pc.Name = dto.Name;
            if (dto.Enabled is bool enabled)
            {
                pc.Enabled = enabled;
            }

            await productRepository.SaveChangesAsync();
        }

        private async Task<bool> IsDescendant(long nodeAId, long nodeBId)
        {
            var all = await AllProductCategoryAsync();
            var lookup = all.ToDictionary(c => c.ProductCategoryId, c => c.ParentId);

            var current = nodeBId;
            while (lookup.TryGetValue(current, out var parentId))
            {
                if (parentId == nodeAId)
                    return true;
                if (parentId == null)
                    return false;
                current = parentId.Value;
            }
            return false;
        }


        public Task<List<ProductCategoryDTO>> AllProductCategoryAsync()
        {
            return AllProductCategoryAsync(false);
        }

        public Task<List<ProductCategoryDTO>> AllProductCategoryAsync(bool enabled)
        {
            return AllProductCategoryAsync(enabled, false);
        }

        public async Task<List<ProductCategoryDTO>> AllProductCategoryAsync(bool enabled, bool final)
        {
            var categories = await productRepository.GetAllProductCategoriesAsync();
            return productMapper.CategoryToDTO(categories, enabled, final);
        }

        public async Task<List<SaleProductDTO>> GetAllSaleProductsAsync()
        {
            var products = await productRepository.GetAllSaleProductsAsync();
            return productMapper.SaleProductToDTO(products);
        }

        public async Task<UnitDTO> CreateUnitAsync(UnitDTO unitDto)
        {
            Unit? unit = await productRepository.FindUnitByIdAsync(unitDto.Id);
            if(unit != null)
                return productMapper.ToUnitDTO(unit);

            Unit newUnit = new()
            {
                Name = unitDto.Name,
                TreatAsInteger = unitDto.TreatAsInteger,
            };

            await productRepository.InsertUnitAsync(newUnit);
            await productRepository.SaveChangesAsync();
            return productMapper.ToUnitDTO(newUnit);
        }

        public async Task<List<UnitDTO>> GetAllUnitsAsync()
        {
            var units = await productRepository.GetAllUnitsAsync();
            return productMapper.ToUnitDTO(units);
        }

    }
}
