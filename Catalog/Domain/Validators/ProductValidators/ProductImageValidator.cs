using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.ProductValidators;

public class ProductImageValidator : AbstractValidator<string>
{
    public ProductImageValidator()
    {
        RuleFor(image => image)
            .NotEmpty().WithMessage("Image is required.");
    }
}
