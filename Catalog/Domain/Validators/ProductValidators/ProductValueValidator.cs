using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.ProductValidators;

public class ProductValueValidator : AbstractValidator<decimal>
{
    public ProductValueValidator()
    {
        RuleFor(value => value)
            .GreaterThan(0).WithMessage("Value must be greater than 0.");
    }
}
