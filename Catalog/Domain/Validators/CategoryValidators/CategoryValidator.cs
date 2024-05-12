using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.CategoryValidators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name).SetValidator(new CategoryNameValidator());

        RuleFor(c => c.Code).SetValidator(new CategoryCodeValidator());
    }
}
