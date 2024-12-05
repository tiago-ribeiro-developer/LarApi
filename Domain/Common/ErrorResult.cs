namespace Domain.Common;

public abstract class ErrorResult
{
    private readonly string _message;

    public Guid Id { get; } = Guid.NewGuid();
    public string Type { get; }
    public string Message => FormatMessage(_message);
    public string Details { get; }
    public ErrorResult? InnerError { get; }

    public ErrorResult(string message, string? details = null, ErrorResult? innerError = null)
    {
        _message = message;

        Type = GetType().Name;
        Details = details ?? string.Empty;
        InnerError = innerError;
    }

    public virtual string FormatMessage(string message) => message;

    public object toErrorResponse()
    {
        throw new NotImplementedException();
    }
}