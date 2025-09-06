using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using CafeFlow.Framework.ExceptionAgg.Exception;
using CafeFlow.Framework.LogAgg.Log.Contracts;
using Microsoft.AspNetCore.Http;


namespace CafeFlow.Framework.ExceptionAgg.ExceptionHandling;

public class ExceptionHandlingMiddleware(RequestDelegate next , ILogService logService)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);

        }
        catch (System.Exception e)
        {
            var statusCode = e switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                CommonExceptionDto commonExceptionDto => commonExceptionDto.StatusCode,
                _ => (int)HttpStatusCode.InternalServerError
            };
            if(statusCode == (int)HttpStatusCode.InternalServerError)
                logService.LogError(e.Message);
            
         
 
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