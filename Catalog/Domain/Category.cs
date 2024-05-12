using FluentValidation;
using NerdStore.Catalog.Domain.Validators.CategoryValidators;
using NerdStore.Core.DomainTypes;

namespace NerdStore.Catalog.Domain;

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
        ValidatorUtils.ValidateEntity(new CategoryValidator(), this);
    } 
}