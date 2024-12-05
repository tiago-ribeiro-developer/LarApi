using Domain.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers.Common;

[ApiController]
public class ApiBase : ControllerBase
{
    private readonly ICollection<string> _errors = new List<string>();

    protected ActionResult? CustomResponse(object? result = null)
    {
        if (IsOperationValid())
        {
            return Ok(result);
        }

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", _errors.ToArray() }
        }));
    }

    protected ActionResult? CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            AddError(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected ActionResult? CustomResponse(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddError(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected bool IsOperationValid()
    {
        return !_errors.Any();
    }

    protected void AddError(string erro)
    {
        _errors.Add(erro);
    }

    protected void ClearErrors()
    {
        _errors.Clear();
    }

    protected ActionResult<TR> AsCreatedResult<TR>(Result<TR> result, Uri? resource)
        => result.IsError
            ? BuildErrorObjectResult(result.UnwrapError())
            : resource == null
                ? new CreatedResult(string.Empty, result.Unwrap())
                : new CreatedResult(resource, result.Unwrap());

    protected ActionResult<TR> AsOkResult<TR>(Result<TR> result)
        => result.IsError
            ? BuildErrorObjectResult(result.UnwrapError())
            : new OkObjectResult(result.Unwrap());

    protected ObjectResult BuildErrorObjectResult(ErrorResult error)
    {
        var errorResponse = new HttpErrorResponse();
        errorResponse.Type = error.Type;
        errorResponse.Message = error.Message;
        errorResponse.Details = error.Details;
        errorResponse.RequestId = HttpContext.TraceIdentifier;
        errorResponse.StatusCode = error.ToHttpStatusCode();

        return new ObjectResult(errorResponse) { StatusCode = (int)errorResponse.StatusCode };
    }
}