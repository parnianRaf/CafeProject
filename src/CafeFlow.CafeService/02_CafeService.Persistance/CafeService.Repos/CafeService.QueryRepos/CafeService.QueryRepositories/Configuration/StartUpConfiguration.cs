using CafeService.FrameWorks.Contracts.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.QueryRepositories.Configuration;

public static class StartUpConfiguration
{
    public static void StartUpQueriesRepoConfiguration(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseGenericRepository<>) , typeof(BaseGenericRepository<>));
        
    } 
}