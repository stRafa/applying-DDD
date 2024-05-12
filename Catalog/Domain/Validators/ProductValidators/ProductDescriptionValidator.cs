using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.ProductValidators;

public class ProductDescriptionValidator : AbstractValidator<string>
{
    public ProductDescriptionValidator()
    {
        RuleFor(description => description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}
