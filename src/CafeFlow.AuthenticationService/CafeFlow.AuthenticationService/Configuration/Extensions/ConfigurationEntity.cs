using Microsoft.IdentityModel.Tokens;

namespace CafeFlow.AuthenticationService.Configuration.Extensions;

public  class ConfigurationEntity
{
    
    public static SymmetricSecurityKey? SecurityKey { get; set; }
    
    public static SigningCredentials? SigningCredentials { get; set; }
    
    public static string? Issuer { get; set; }
    
    public static string? Audience { get; set; }
    
    
}