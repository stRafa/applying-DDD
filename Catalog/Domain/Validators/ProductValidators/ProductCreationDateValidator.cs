using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.ProductValidators;

public class ProductCreationDateValidator : AbstractValidator<DateTime>
{
    public ProductCreationDateValidator()
    {
        RuleFor(createDate => createDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Creation date cannot be in the future.");
    }
}
