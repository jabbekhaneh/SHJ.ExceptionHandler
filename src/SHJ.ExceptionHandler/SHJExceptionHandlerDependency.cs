using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SHJ.ExceptionHandler.Middlewares;
using SHJ.ExceptionHandler.Options;

namespace SHJ.ExceptionHandler;

public static class SHJExceptionHandlerDependency
{
    public static IServiceCollection AddSHJExceptionHandler(this IServiceCollection services,Action<ExceptionHandlerOption> option)
    {   
        services.Configure<ExceptionHandlerOption>(option);
        return services;
    }

    public static IApplicationBuilder UseSHJExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddlewareHandler>();
    }
}
