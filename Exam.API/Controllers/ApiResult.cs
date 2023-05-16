using System.Net;

namespace Exam.API.Controllers;

public class ApiResult
{
    public object? Body { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }

    public static ApiResult Created(object? body = null)
    {
        return new ApiResult()
        {
            Body = body,
            StatusCode = HttpStatusCode.Created,
            Message = "created"
        };
    }

    public static ApiResult NotFound(object? body = null)
    {
        return new ApiResult()
        {
            StatusCode = HttpStatusCode.NotFound,
            Message = "not-found",
            Body = body
        };
    }

    public static ApiResult Updated(object? body = null)
    {
        return new ApiResult()
        {
            StatusCode = HttpStatusCode.OK,
            Message = "updated",
            Body = body
        };
    }

    public static ApiResult OK(object? body = null)
    {
        return new ApiResult()
        {
            StatusCode = HttpStatusCode.OK,
            Body = body,
            Message = "Successful"
        };
    }
}