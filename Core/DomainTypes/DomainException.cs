using System.Diagnostics;
using FluentValidation;
using FluentValidation.Results;

namespace NerdStore.Core.DomainTypes;

public class EntityValidationException : Exception
{    
    public EntityValidationException(List<ValidationFailure> errors)
    {
        if (errors.Count == 0)
        {
            throw new ArgumentException("Errors cannot be an empty list.", nameof(errors));
        }
        var classType = new StackTrace().GetFrame(1)?.GetType();

        string message = $"Validation failed instantiating a {classType.Name}";
        
        throw new ValidationException(message, errors);
    }
}