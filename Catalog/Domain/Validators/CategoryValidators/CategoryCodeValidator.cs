using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.CategoryValidators;

public class CategoryCodeValidator : AbstractValidator<int>
{
    public CategoryCodeValidator()
    {
        RuleFor(code => code)
            .NotEmpty().WithMessage("Code is required.")
            .NotEqual(0).WithMessage("Code must be different that 0.");
    }
}