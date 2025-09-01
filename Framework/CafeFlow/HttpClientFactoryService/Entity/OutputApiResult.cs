namespace CafeFlow.Framework.HttpClientFactoryService.Entity;

public class OutputApiResult
{
    private OutputApiResult(int statusCode, string? message, object? data)
    {
        statusCode = statusCode;
        message = message;
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
    
}