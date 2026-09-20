using FluentValidation;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public long MaxProductId = long.MaxValue - 1024;
        public int NameMinLength = 3;
        public int NameMaxLength = 256;
        public int DescriptionMaxLength = 256;
        public CreateProductValidator()
        {
            RuleFor(createProduct => createProduct.Name).NotEmpty().Length(NameMinLength, NameMaxLength);
            RuleFor(createProduct => createProduct.Description).MaximumLength(DescriptionMaxLength);
            RuleFor(createProduct => createProduct.CategoryId).NotEmpty().InclusiveBetween(1, MaxProductId);
            RuleFor(createProduct => createProduct.Quantity).InclusiveBetween(0, decimal.MaxValue - 1);
        }
    }
}
