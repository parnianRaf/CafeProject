using Microsoft.IdentityModel.Tokens;

namespace CafeFlow.Framework.AthenticationToken.Extensions;

public  class ConfigurationEntity
{
    
    public  SymmetricSecurityKey? SecurityKey { get; set; }
    
    public  SigningCredentials? SigningCredentials { get; set; }
    
    public  string? Issuer { get; set; }
    
    public  string? Audience { get; set; }
    
    
}