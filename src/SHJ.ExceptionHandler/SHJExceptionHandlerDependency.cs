using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SHJ.ExceptionHandler.Middlewares;

namespace SHJ.ExceptionHandler;

public static class SHJExceptionHandlerDependency
{
    public static IServiceCollection AddSHJExceptionHandler(this IServiceCollection services)
    {   
        return services;
    }

    public static void UseSHJExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddlewareHandler>();
    }
}
