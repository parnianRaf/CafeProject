using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.SqlCommandRepository.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.CommandRepository.Configuration;

public static class StartUpConfiguration
{
    public static void StartUpCommandRepoConfiguration(this IServiceCollection services)
    {
       services.AddScoped(typeof(IMongoCommandBaseGenericRepository<>) , typeof(MongoCommandBaseGenericRepository<>));
       services.AddScoped<IUnitOfWorks, UnitOfWorks>();
    }
}