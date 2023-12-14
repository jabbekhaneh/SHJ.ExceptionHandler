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
            string message = $"internal error with status code:{ex.StatusCode}- exception message :{ex.Message}";
            _logger.LogError(message, ex);
            var response = new BaseErrorResposne(ex.StatusCode,message);
            await context.Response.WriteAsJsonAsync($"{response}");

        }
        catch (WebServiceException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            string message = $"internal error with status code:{ex.StatusCode}- exception message :{ex.Message}";
            var response = new BaseErrorResposne(ex.StatusCode, message);
            _logger.LogError(message, ex);
            await context.Response.WriteAsJsonAsync($"{response}");

        }
        catch (UnauthorizedAccessException ex)
        {
            var statusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.StatusCode = statusCode;
            string message = $"internal error with status code:{statusCode}- exception message :{ex.Message}";
            var response = new BaseErrorResposne(statusCode, message);
            _logger.LogError(message, ex);
            await context.Response.WriteAsJsonAsync($"{response}");
        }
        catch (KeyNotFoundException ex)
        {
            var statusCode = (int)HttpStatusCode.NotFound;
            context.Response.StatusCode = statusCode;
            string message = $"internal error with status code:{statusCode}- exception message :{ex.Message}";
            var response = new BaseErrorResposne(statusCode, message);
            _logger.LogError(message, ex);
            await context.Response.WriteAsJsonAsync($"{response}");
        }
        catch (ValidationException ex)
        {
            var statusCode = (int)HttpStatusCode.BadRequest;
            context.Response.StatusCode = statusCode;
            string message = $"internal error with status code:{statusCode}- exception message :{ex.Message}";
            var response = new BaseErrorResposne(statusCode, message);
            _logger.LogError(message, ex);
            await context.Response.WriteAsJsonAsync($"{response}");
        }
        catch (Exception ex)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = statusCode;
            string message = $"internal error with status code:{statusCode}- exception message :{ex.Message}";
            var response = new BaseErrorResposne(statusCode, message);
            _logger.LogError(message, ex);
            await context.Response.WriteAsJsonAsync($"{response}");

        }
    }

}
