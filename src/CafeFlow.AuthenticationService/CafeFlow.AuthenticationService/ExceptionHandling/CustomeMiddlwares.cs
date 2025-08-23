namespace CafeFlow.AuthenticationService.ExceptionHandling;

public static class CustomeMiddlwares
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

}