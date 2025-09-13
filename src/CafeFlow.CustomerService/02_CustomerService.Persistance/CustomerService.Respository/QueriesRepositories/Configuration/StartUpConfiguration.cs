using Contracts.RepoContracts;
using Microsoft.Extensions.DependencyInjection;

namespace QueriesRepositories.Configuration;

public static class StartUpConfiguration
{
    public static void StartUpQueriesRepoConfiguration(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseGenericRepository<>) , typeof(BaseGenericRepository<>));
        
    } 
}