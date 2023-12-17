using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SHJ.ExceptionHandler.Exceptions;
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
        _logger.LogInformation($"OPTION EXCEPTION HANDLER VALUE : {_options.Value}");
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {

            await _request(context);
        }
        catch (BaseBusinessException ex)
        {
            _logger.LogError("**** ERROR BaseBusinessException Start ****");
            context.Response.StatusCode = ex.StatusCode;

            string message = $"internal error with ERROR code:{ex.Code} - InnerException Message :{ex.Message}" +
                                                                      $"- InnerException StackTrace {ex.StackTrace}";

            _logger.LogError(message, ex);

            var response = new BaseHttpResponseException(ex.Code, message);

            _logger.LogError($"response server: {response}");

            _logger.LogError("**** ERROR BaseBusinessException End ****");

            await context.Response.WriteAsJsonAsync($"{response}");
        }
        catch (Exception ex)
        {
            _logger.LogError("**** ERROR Exception Start ****");

            string message = $"InnerException Message :{ex.Message}" + $"InnerException StackTrace {ex.StackTrace}";

            _logger.LogError(message, ex);

            _logger.LogError("**** ERROR Exception END ****");
        }
    }

}
