using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CafeFlow.Framework.ExceptionAgg.Exception;
using System;
public class CommonExceptionDto :Exception
{

    public int StatusCode { get; }
    public string? Detail { get; set; }
    
    private CommonExceptionDto(string message, int statusCode = (int)HttpStatusCode.BadRequest,string? detail = null)
        : base(message)
    {
        StatusCode = statusCode;
        Detail = detail;
    }

    public static CommonExceptionDto GenerateCommonException(string message )
    {
        return new(message);
    }
    public static CommonExceptionDto GenerateCommonException(string message , int statusCode)
    {
        return new(message ,statusCode);
    }
    public static CommonExceptionDto GenerateCommonException(string message , int statusCode , string detail)
    {
        return new(message ,statusCode, detail);
    }
    


}