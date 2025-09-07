using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CafeFlow.Framework.ExceptionAgg.Exception;
using System;
public class CommonExceptionDto :Exception
{

    public int StatusCode { get; }
    
    private CommonExceptionDto(string message, int statusCode = (int)HttpStatusCode.BadRequest)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public static CommonExceptionDto GenerateCommonException(string message )
    {
        return new(message);
    }
    public static CommonExceptionDto GenerateCommonException(string message , int statusCode)
    {
        return new(message , statusCode);
    }
    


}