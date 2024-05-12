using FluentValidation;
using NerdStore.Core.DomainTypes;

public static class ValidatorUtils
{
    public static void ValidateEntity(IValidator validator, dynamic entity)
    {
        var validationResult = validator.Validate(entity);

        if (!validationResult.IsValid)
            throw new EntityValidationException(validationResult.Errors);   
    }

    public static void ValidateProperty(IValidator validator, dynamic property)
    {
        var validationResult = validator.Validate(property);

        if (!validationResult.IsValid)
            throw new EntityPropertyValidationException(validationResult.Errors, nameof(property));   
    }
}