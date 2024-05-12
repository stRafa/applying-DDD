using System.Diagnostics;
using FluentValidation;
using FluentValidation.Results;

namespace NerdStore.Core.DomainTypes;

public class EntityValidationException : DomainException
{    
    public EntityValidationException(List<ValidationFailure> errors)
    {
        if (errors.Count == 0)
            throw new ArgumentException("Errors cannot be an empty list.", nameof(errors));
        
        var classType = new StackTrace().GetFrame(1)?.GetType();

        string message = $"Validation failed instantiating a {classType?.Name}";
        
        throw new ValidationException(message, errors);
    }
}

public class EntityPropertyValidationException : DomainException
{
    public EntityPropertyValidationException(List<ValidationFailure> errors, string propertyName)
    {
        if (errors.Count == 0)
            throw new ArgumentException("Errors cannot be an empty list.", nameof(errors));

        var classType = new StackTrace().GetFrame(1)?.GetType();

        string message = $"Validation failed on property {propertyName} of the entity {classType?.Name}";

        throw new ValidationException(message, errors);
    }
}