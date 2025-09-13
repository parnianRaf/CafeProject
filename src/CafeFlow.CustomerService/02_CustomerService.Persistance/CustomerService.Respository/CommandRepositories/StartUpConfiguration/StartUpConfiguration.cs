using Contracts.RepoContracts;
using Microsoft.Extensions.DependencyInjection;

namespace CommandRepositories.StartUpConfiguration;

public static class StartUpConfiguration
{
    public static void SqlCommandRepoConfigure(this IServiceCollection services)
    {
        services.AddScoped(typeof(ISqlBaseGenericRepository<>) , typeof(SqlBaseGenericRepository<>));
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
    }
}