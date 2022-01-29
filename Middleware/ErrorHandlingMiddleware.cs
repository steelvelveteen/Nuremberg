using Newtonsoft.Json;
namespace Nuremberg;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        if (exception is DllNotFoundException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            httpContext.Response.ContentType = "application/json";

        }

        var responseBody = JsonConvert.SerializeObject(
            new
            {
                status = (int)httpContext.Response.StatusCode,
                message = exception.Message
            }
        );

        return httpContext.Response.WriteAsync(responseBody);
    }
}