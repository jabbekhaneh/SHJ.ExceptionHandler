using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ServiceStack;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SHJ.ExceptionHandler.Middlewares;

public class ExceptionMiddlewareHandler
{
    private readonly RequestDelegate _request;

    private readonly ILogger<ExceptionMiddlewareHandler> _logger;
    public ExceptionMiddlewareHandler(RequestDelegate request,
                                      ILogger<ExceptionMiddlewareHandler> logger)
    {
        _request = request;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (BaseException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync($"message :{ex.Message}- status:{ex.StatusCode}");

        }
        catch (WebServiceException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync($"message :{ex.Message}- status:{ex.StatusCode}");

        }
        catch (UnauthorizedAccessException ex)
        {
            var statusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync($"message :{ex.Message}- status:{statusCode}");
        }
        catch (KeyNotFoundException ex)
        {
            var statusCode = (int)HttpStatusCode.NotFound;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync($"message :{ex.Message}- status:{statusCode}");
        }
        catch (ValidationException ex)
        {
            var statusCode = (int)HttpStatusCode.BadRequest;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync($"message :{ex.Message}- status:{statusCode}");
        }
        catch (Exception ex)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync($"message :{ex.Message}- status:{statusCode}");
        }
    }

}
