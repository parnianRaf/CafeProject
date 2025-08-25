using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using CafeFlow.AuthenticationService.ExceptionHandling.ExceptionDtos;
using Microsoft.AspNetCore.Identity;

namespace CafeFlow.AuthenticationService.ExceptionHandling;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var statusCode = e switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                IdentityException identityException => identityException.StatusCode,
                _ => (int)HttpStatusCode.InternalServerError
            };
            
 
            var errorResponse = new
            {
                statusCode = statusCode,
                message = e.Message,
                #if DEBUG
                details = e.StackTrace,
                #else
                details = null,
                #endif
            };

            var json = JsonSerializer.Serialize(errorResponse);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);


        }
    }
}