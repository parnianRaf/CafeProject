using Microsoft.AspNetCore.Identity;

namespace CafeFlow.Framework.ExceptionAgg.ExceptionHandling.ExceptionDtos;

public class IdentityException : System.Exception
{
    public int StatusCode { get; set; }
    
    public IdentityException(string message, int statusCode = 400)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public IdentityException(IEnumerable<IdentityError> errors, int statusCode = 400)
        : base(string.Join("; ", errors.Select(e => e.Description)))
    {
        StatusCode = statusCode;
    }
    
}