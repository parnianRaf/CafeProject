using CafeService.MongoDbApp.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.MongoDbApp.Configuration;

public static class StartUpConfiguration
{
    public static void StartUpMongoDbConfiguration(this IServiceCollection services)
    {
        services.AddScoped<MongoDb>();
        
    }
}