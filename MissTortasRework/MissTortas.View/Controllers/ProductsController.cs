using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(
            IProductService productService,
            IValidator<UpdateProductRequest> updateProductValidator,
            IValidator<CreateProductRequest> createProductValidator
        ) : ControllerBase
    {

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var ps = await productService.AllWithDetailAsync();
            return ps.ToList();
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDTO>> PutProduct(long productId, UpdateProductRequest dto)
        {
            await updateProductValidator.ValidateAndThrowAsync(dto);
            var productDto = new UpdateProductDTO
            {
                ProductId = productId,
                CategoryId = dto.CategoryId,
                Quantity = dto.Quantity,
                Description = dto.Description,
                Enabled = dto.Enabled
            };
            var product = await productService.UpdateProductAsync(productDto);
            return product;
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(CreateProductRequest dto)
        {
            await createProductValidator.ValidateAndThrowAsync(dto);
            var productDto = new ProductCreateDTO
            {
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Quantity = dto.Quantity,
                UnitId = dto.UnitId
            };
            var p = await productService.CreateProductAsync(productDto);
            return p;
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet("units")]
        public async Task<List<UnitDTO>> GetUnits()
        {
            var p = await productService.GetAllUnitsAsync();
            return p;
        }

    }
}
