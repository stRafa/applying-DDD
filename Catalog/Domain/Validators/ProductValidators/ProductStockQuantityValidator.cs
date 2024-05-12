using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.ProductValidators;

public class ProductStockQuantityValidator : AbstractValidator<int>
{
    public ProductStockQuantityValidator()
    {
        RuleFor(stockQuantity => stockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
    }
}
