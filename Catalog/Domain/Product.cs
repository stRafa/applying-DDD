using NerdStore.Catalog.Domain.Validators.ProductValidators;
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

        Validate();
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
        ValidatorUtils.ValidateProperty(new ProductDescriptionValidator(), description);
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
        ValidatorUtils.ValidateEntity(new ProductValidator(), this);
    }
}
