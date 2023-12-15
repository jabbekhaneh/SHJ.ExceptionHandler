using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SHJ.ExceptionHandler.http;
using SHJ.ExceptionHandler.Options;

namespace SHJ.ExceptionHandler.Middlewares;

public class ExceptionMiddlewareHandler
{
    private readonly RequestDelegate _request;
    private readonly ILogger<ExceptionMiddlewareHandler> _logger;
    private readonly IOptions<ExceptionHandlerOption> _options;
    public ExceptionMiddlewareHandler(RequestDelegate request,
                                      ILogger<ExceptionMiddlewareHandler> logger,
                                      IOptions<ExceptionHandlerOption> options)
    {
        _request = request;
        _logger = logger;
        this._options = options;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {

            await _request(context);
        }
        catch (BaseBusinessException ex)
        {
            context.Response.StatusCode = _options.Value.ServerError;
            string message = $"internal error with ERROR code:{ex.Code}- exception message :{ex.Message}";
            _logger.LogError(message, ex);
            var response = new BaseHttpResponseException(ex.Code, message);
            await context.Response.WriteAsJsonAsync($"{response}");
        }
    }

}
