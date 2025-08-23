using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CafeFlow.AuthenticationService.Configuration.Extensions;

public class ConfigurationSet
{
    public ConfigurationSet(IConfiguration configuration)
    {
        var key = configuration["Authentication:Key"]!;
        ConfigurationEntity.SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        ConfigurationEntity.SigningCredentials = new SigningCredentials(ConfigurationEntity.SecurityKey, SecurityAlgorithms.HmacSha256); 
        ConfigurationEntity.Audience = configuration["Authentication:Audience"]!;
        ConfigurationEntity.Issuer = configuration["Authentication:Issuer"]!;
    }
  
}