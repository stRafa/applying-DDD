using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.CategoryValidators;

public class CategoryNameValidator : AbstractValidator<string>
{
    public CategoryNameValidator()
    {
        RuleFor(name => name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must have between 2 and 100 characters.");
    }
}
