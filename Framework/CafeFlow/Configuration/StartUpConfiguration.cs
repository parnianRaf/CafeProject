using System.Text;
using CafeFlow.Framework.AthenticationToken.Extensions;
using CafeFlow.Framework.LogAgg.Log.Contracts;
using CafeFlow.Framework.LogAgg.LogService;
using CafeFlow.Framework.Provider.Notification.Service;
using CafeFlow.Framework.Provider.Notification.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;


namespace CafeFlow.Framework.Configuration;

public static class StartUpConfiguration
{
    public static IHostBuilder AddStartup(this IServiceCollection services , IHostBuilder hostBuilder , IConfiguration configure)
    {
        services.AddHttpClient<NotificationService>("NotificationService" , client =>
        {
            client.BaseAddress = new Uri("http://localhost:5042");
        });
        services.AddScoped<INotificationService, NotificationService>();

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("CommonConfiguration.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        hostBuilder.UseSerilog((_, configuration) =>
            configuration.ReadFrom.Configuration(config));
        var key = configure["Authentication:Key"]!;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); 
        services.AddSingleton<ConfigurationEntity>(_ =>
        {

            return new ConfigurationEntity()
            {
                SecurityKey = securityKey,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256), 
                Audience = configure["Authentication:Audience"]!, 
                Issuer = configure["Authentication:Issuer"]!
            };
        });
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configure["Authentication:Issuer"]!,
                        ValidAudience = configure["Authentication:Audience"]!,
                        IssuerSigningKey = securityKey
                    };
                }
            );
         

        services.AddSingleton<ILogService, LogService>();
        return hostBuilder;
    }
}