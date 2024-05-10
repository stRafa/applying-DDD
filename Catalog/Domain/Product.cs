using FluentValidation;
using NerdStore.Core.DomainTypes;

namespace NerdStore.Catalog.Domain;

public class Product : Entity, IAggregateRoot
{
    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool Status { get; private set; }
    public decimal Value { get; private set; }
    public DateTime CreateDate { get; private set; }
    public string Image { get; private set; }
    public int StockQuantity { get; private set; }
    public Category? Category { get; private set; }
    
    public Product(string name, string description, bool status, decimal value, DateTime createDate, string image, Guid categoryId)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        Status = status;
        Value = value;
        CreateDate = createDate;
        Image = image;
    }

    public void Activate() => Status = true;

    public void Deactivate() => Status = false;

    public void ChangeCategory(Category category)
    {
        Category = category;
        CategoryId = category.Id;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }

    public void DebitStock(int quantity)
    {
        if (quantity < 0) quantity *= -1;
        StockQuantity -= quantity;
    }

    public void RefillStock(int quantity)
    {
        StockQuantity += quantity;
    }

    public bool HasStock(int quantity) => StockQuantity >= quantity;

    protected override void Validate() 
    {
        var validationResult = new Validator().Validate(this);

        if (!validationResult.IsValid)
            throw new EntityValidationException(validationResult.Errors);
    } 
    

    private class Validator : AbstractValidator<Product>
    {
        public Validator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must have between 2 and 100 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(p => p.Value)
                .GreaterThan(0).WithMessage("Value must be greater than 0.");

            RuleFor(p => p.CreateDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Creation date cannot be in the future.");

            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("Image is required.");

            RuleFor(p => p.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
        }
    }
}

public class Category : Entity
{
    public string Name { get; private set; }
    public int Code { get; private set; }

    public Category(string name, int code)
    {
        Name = name;
        Code = code;
    }

    public override string ToString()
    {
        return $"{Name} - {Code}";
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}