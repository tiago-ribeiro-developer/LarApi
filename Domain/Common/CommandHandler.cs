using FluentValidation.Results;

namespace Domain.Common;

public abstract class CommandHandler
{
    protected ValidationResult ValidationResult;

    protected CommandHandler()
    {
        ValidationResult = new ValidationResult();
    }

    protected void AddError(string mensagem)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
    }
}