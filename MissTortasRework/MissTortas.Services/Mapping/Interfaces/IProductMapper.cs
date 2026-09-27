using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IProductMapper
    {
        public UnitDTO ToUnitDTO(Unit unit);
        public List<UnitDTO> ToUnitDTO(IEnumerable<Unit> unit);
        public List<ProductDTO> ProductToDTO(IEnumerable<ProductDADto> products);
        public List<ProductDTO> ProductToDTO(IEnumerable<Product> products);
        public ProductDTO ProductToDTO(Product product);
        public ProductDTO ProductToDTO(ProductDADto product);
        public SaleProductDTO SaleProductToDTO(SaleProduct product);
        public SaleProductDTO SaleProductToDTO(SaleProductDADto product);
        public List<SaleProductDTO> SaleProductToDTO(IEnumerable<SaleProductDADto> dtos);
        public List<SaleProductDTO> SaleProductToDTO(IEnumerable<SaleProduct> products);
        public List<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> product, bool onlyEnabled, bool onlyFinal);
        public List<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> product, bool onlyEnabled);
        public ProductCategoryDTO CategoryToDTO(ProductCategory product);
        public List<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> product);
        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc);
        public List<ChildrenProductCategoryDTO> ChildrenProductCategoryToDTO(IEnumerable<ProductCategory> pc);
    }
}
