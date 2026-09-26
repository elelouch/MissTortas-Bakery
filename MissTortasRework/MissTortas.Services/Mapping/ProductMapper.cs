using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping.Interfaces;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Services.Mapping
{
    public class ProductMapper : IProductMapper
    {
        public List<UnitDTO> ToUnitDTO(IEnumerable<Unit> units)
        {
            return [.. units.Select(ToUnitDTO)];
        }

        public UnitDTO ToUnitDTO(Unit unit)
        {
            return new UnitDTO
            {
                Id = unit.Id,
                Name = unit.Name,
                TreatAsInteger = unit.TreatAsInteger
            };
        }

        public ProductCategoryDTO CategoryToDTO(ProductCategory category)
        {
            return new ProductCategoryDTO
            {
                Enabled = category.Enabled,
                ProductCategoryId = category.ProductCategoryId,
                ParentId = category.ParentId,
                IsFinal = category.IsFinal,
                Name = category.Name,
                Children = []
            };
        }

        public List<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> categories)
        {
            return CategoryToDTO(categories, false, false);
        }
        public List<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> categories, bool onlyEnabled)
        {
            return CategoryToDTO(categories, onlyEnabled, false);
        }
        public List<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> categories, bool onlyEnabled, bool onlyFinal)
        {
            var dtoLookup = new Dictionary<long, ProductCategoryDTO>(categories.Count());

            foreach (var cat in categories)
            {
                if (onlyFinal && !cat.IsFinal || onlyEnabled && !cat.Enabled)
                {
                    continue;
                }
                dtoLookup[cat.ProductCategoryId] = CategoryToDTO(cat);
            }

            var roots = new List<ProductCategoryDTO>();

            foreach (var c in categories)
            {
                if (onlyFinal && !c.IsFinal || onlyEnabled && !c.Enabled)
                {
                    continue;
                }
                var dto = dtoLookup[c.ProductCategoryId];

                if (c.ParentId == 0)
                {
                    roots.Add(dto);
                }
                else
                {
                    if (dtoLookup.TryGetValue(c.ParentId ?? 0, out var parent))
                    {
                        parent.Children.Add(dto);
                    }
                    else
                    {
                        roots.Add(dto);
                    }
                }
            }
            return roots;
        }

        public List<ProductDTO> ProductToDTO(IEnumerable<Product> products)
        {
            return [.. products.Select(p => ProductToDTO(p))];
        }

        public ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.ProductId,
                Name = product.Name,
                Description = product.ProductDetail?.Description ?? string.Empty,
                CategoryId = product.ProductCategoryId,
                UnitId = product.Unit.Id,
                Quantity = product.Quantity,
                Enabled = product.Enabled
            };
        }

        public SaleProductDTO SaleProductToDTO(SaleProduct product)
        {
            return new SaleProductDTO
            {
                Id = product.SaleProductId,
                Name = product.Product.Name,
                Price = product.SalePrice,
                Quantity = product.SaleQuantity,
                StockProductId = product.ProductId
            };
        }

        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc)
        {
            return new ChildrenProductCategoryDTO
            {
                Id = pc.ProductCategoryId,
                Name = pc.Name
            };
        }

        public List<ChildrenProductCategoryDTO> ChildrenProductCategoryToDTO(IEnumerable<ProductCategory> pc)
        {
            throw new NotImplementedException();
        }

        public List<SaleProductDTO> SaleProductToDTO(IEnumerable<SaleProduct> products)
        {
            return [.. products.Select(prod => SaleProductToDTO(prod))];
        }

        public ProductDTO ProductToDTO(ProductDADto product)
        {
            return new ProductDTO
            {
                CategoryId = product.CategoryId,
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                UnitId = product.UnitId,
                Quantity = product.Quantity,
                Enabled = product.Enabled
            };
        }

        public List<ProductDTO> ProductToDTO(IEnumerable<ProductDADto> products)
        {
            return [.. products.Select(p => ProductToDTO(p))];
        }

        public SaleProductDTO SaleProductToDTO(SaleProductDADto dto)
        {
            return new SaleProductDTO
            {
                Id = dto.Id,
                Quantity = dto.SaleQuantity,
                Price = dto.SalePrice,
                Name = dto.Name,
                Description = dto.Description,
                StockProductId = dto.StockProductId
            };
        }
        public List<SaleProductDTO> SaleProductToDTO(IEnumerable<SaleProductDADto> dtos)
        {
            return [.. dtos.Select(dto => SaleProductToDTO(dto))];
        }
    }
}
