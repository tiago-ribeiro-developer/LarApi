using FluentValidation.Results;

namespace Domain.Common;

public abstract class EntityBase
{
    public int Id { get; protected set; }
    public ValidationResult? ValidationResult { get; private set; }
}