using CafeFlow.Framework.HttpClientFactoryService;
using CafeFlow.Framework.HttpClientFactoryService.Service;
using CafeFlow.Framework.LogAgg.Log.Contracts;
using CafeFlow.Framework.LogAgg.LogService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;


namespace CafeFlow.Framework.Configuration;

public static class StartUpConfiguration
{
    public static IHostBuilder AddStartup(this IServiceCollection services , IHostBuilder hostBuilder)
    {
        services.AddHttpClient<NotificationService>("NotificationService" , client =>
        {
            client.BaseAddress = new Uri("http://localhost:5042");
        });

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("CommonConfiguration.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        hostBuilder.UseSerilog((_, configuration) =>
            configuration.ReadFrom.Configuration(config));
         

        services.AddSingleton<ILogService, LogService>();
        return hostBuilder;
    }
}