using System.Net;
using Domain.Common;

namespace Api.Controllers.Common;

public static class ErrorResultTransateHttpStatusCodeExtension
{
    public static HttpStatusCode ToHttpStatusCode(this ErrorResult errorResult)
        => errorResult switch
        {
            _ => HttpStatusCode.BadRequest
        };
}
