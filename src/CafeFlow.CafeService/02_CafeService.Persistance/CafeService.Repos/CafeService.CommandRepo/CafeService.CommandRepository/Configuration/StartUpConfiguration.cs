using CafeService.FrameWorks.Contracts.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.CommandRepository.Configuration;

public static class StartUpConfiguration
{
    public static void StartUpCommandRepoConfiguration(this IServiceCollection services)
    {
       services.AddScoped(typeof(IMongoCommandBaseGenericRepository<>) , typeof(MongoCommandBaseGenericRepository<>));
        
    }
}