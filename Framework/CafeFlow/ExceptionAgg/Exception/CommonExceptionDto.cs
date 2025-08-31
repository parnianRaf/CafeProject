using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CafeFlow.Framework.ExceptionAgg.Exception;
using System;
public class CommonExceptionDto :Exception
{

    public int StatusCode { get; }
    
    public CommonExceptionDto(Exception exception)
        : base(exception.Message)
    {
        StatusCode = exception switch
        {
            // ValidationException => (int)HttpStatusCode.BadRequest,
            // IdentityException identityException => identityException.StatusCode,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }

}