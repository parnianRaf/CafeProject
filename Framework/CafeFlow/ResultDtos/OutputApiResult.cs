using System.Net;

namespace CafeFlow.Framework.ResultDtos;

public class OutputApiResult
{
    private OutputApiResult(int statusCode, string? message, object? data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }
    public int StatusCode { get; set; }
    public string? Message { get; set; } 
    public object? Data { get; set; }
    public bool IsSuccessStatusCode => (StatusCode >= 200) && ((int)StatusCode <= 299);

    public static OutputApiResult GenerateOutputApiResult(int statusCode, string? message, object? data)
    {
        return new(statusCode, message, data);
    }
    
    public static OutputApiResult GenerateOutputApiResult(OutPutDto outPut)
    {
        var finalResultStatusCode = outPut.IsValid ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;
        return new(finalResultStatusCode,outPut.Message,null);
    } 
    
}