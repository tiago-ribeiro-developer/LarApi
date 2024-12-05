using System.Net;
using System.ComponentModel;

namespace Api.Controllers.Common;

public sealed class HttpErrorResponse
{
    [DefaultValue("")]
    public string Type { get; set; }

    [DefaultValue("")]
    public string Message { get; set; }

    [DefaultValue(HttpStatusCode.InternalServerError)]
    public HttpStatusCode? StatusCode { get; set; }

    [DefaultValue("")]
    public string Details { get; set; }

    [DefaultValue("")]
    public string RequestId { get; set; }
    public List<HttpErrorResponse>? InnerErrors { get; set; }
}