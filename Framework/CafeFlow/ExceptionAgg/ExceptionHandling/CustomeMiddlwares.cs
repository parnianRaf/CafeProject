using Microsoft.AspNetCore.Builder;

namespace CafeFlow.Framework.ExceptionAgg.ExceptionHandling;

public static class CustomeMiddlwares
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

}