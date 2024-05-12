using FluentValidation;

namespace NerdStore.Catalog.Domain.Validators.ProductValidators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).SetValidator(new ProductNameValidator());
        RuleFor(p => p.Description).SetValidator(new ProductDescriptionValidator());
        RuleFor(p => p.Value).SetValidator(new ProductValueValidator());
        RuleFor(p => p.CreateDate).SetValidator(new ProductCreationDateValidator());
        RuleFor(p => p.Image).SetValidator(new ProductImageValidator());
        RuleFor(p => p.StockQuantity).SetValidator(new ProductStockQuantityValidator());
    }
}