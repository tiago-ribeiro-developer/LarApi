namespace Domain.Common;

public class Result<T>
{
    
    private T? Ok { get; }
    private ErrorResult? Error { get; }

    public Result(T ok) => Ok = ok;

    public Result(ErrorResult error) => Error = error;

    public bool IsError => Error != null && !string.IsNullOrEmpty(Error.Message);
    public bool IsOk => Ok is not null && !IsError;

    public T Unwrap()
    {
        if (Ok is null)
            throw new Exception("Failed to unwrap a result that is not of type Success");

        return Ok;
    }

    public ErrorResult UnwrapError()
    {
        if (Error is null)
            throw new Exception("Failed to unwrap a result that is not of type Error");

        return Error;
    }

    public static implicit operator Result<T>(T successResult) => new(successResult);
    public static implicit operator Result<T>(ErrorResult errorResult) => new(errorResult);
}

public class Result
{
    private ErrorResult? Error { get; }

    public Result() => Error = null;

    public Result(ErrorResult error) => Error = error;

    public bool IsError => Error != null && !string.IsNullOrEmpty(Error.Message);

    public ErrorResult UnwrapError()
    {
        if (Error is null)
            throw new Exception("Failed to unwrap a result that is not of type Error");

        return Error;
    }

    public static implicit operator Result(ErrorResult errorResult) => new(errorResult);

    public static Result Empty = new();
}