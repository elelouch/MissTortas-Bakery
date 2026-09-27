using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Products;
using MissTortas.View.Mappers;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleProductsController(
        IValidator<CreateSaleProductRequest> createSaleProductValidator,
        IProductService productService,
        ISimpleStorage simpleStorage,
        IPresentationProductMapper presentationProductMapper
    ) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet]
        public async Task<ActionResult<List<SaleProductResponse>>> GetAllSaleProducts()
        {
            var saleProducts = await productService.GetAllSaleProductsAsync();
            var ids = saleProducts.Select(sp => sp.Id).ToArray();
            var filePaths = await simpleStorage.GetProductFilesAsync(ids);
            var ret = presentationProductMapper.MapDtoToResponse(saleProducts, filePaths);
            return ret;
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<SaleProductResponse>> PostSaleProduct([FromForm] CreateSaleProductRequest dto, [FromForm] List<IFormFile> files)
        {
            await createSaleProductValidator.ValidateAndThrowAsync(dto);
            var saleProductDto = presentationProductMapper.MapCreateSaleProductRequestToDTO(dto);
            var saleProduct = await productService.CreateSaleProductAsync(saleProductDto);
            var retFiles = await simpleStorage.SaveProductFileAsync(files, saleProduct.Id);
            var ret = presentationProductMapper.MapDtoToResponse(saleProduct, [.. retFiles.Select(f => f.Path)]);
            return ret;
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPut("{saleProductId}")]
        public async Task<ActionResult<SaleProductResponse>> PutSaleProduct(long saleProductId, [FromForm] UpdateSaleProductRequest updateSaleProductDTO, [FromForm] List<IFormFile> files)
        {
            var saleProductDto = presentationProductMapper.MapUpdateRequestToDto(saleProductId, updateSaleProductDTO);
            var saleProduct = await productService.UpdateSaleProductAsync(saleProductDto);
            var retFiles = await simpleStorage.SaveProductFileAsync(files, saleProduct.Id);
            var ret = presentationProductMapper.MapDtoToResponse(saleProduct, [.. retFiles.Select(f => f.Path)]);
            return ret;
        }
    }
}
