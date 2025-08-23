using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace CafeFlow.AuthenticationService.ExceptionHandling;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var statusCode = e switch
            {
                ValidationException =>HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
            if (e.GetType() == typeof(ValidationException))
            {
                context.Response.ContentType = "application/json";
                var errorResponse = new
                {
                    statusCode,
                    message = "An unexpected error occurred.",
                    detail = e.Message 
                };

                var json = JsonSerializer.Serialize(errorResponse);

                await context.Response.WriteAsync(json);
            }
            Console.WriteLine(e);
            throw;
        }
    }
}