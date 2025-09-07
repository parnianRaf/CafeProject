using CafeService.FrameWorks.Contracts.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.SqlCommandRepository.StartUpConfiguration;

public static class StartUpConfiguration
{
    public static void SqlCommandRepoConfigure(this IServiceCollection services)
    {
        services.AddScoped(typeof(ISqlBaseGenericRepository<>) , typeof(SqlBaseGenericRepository<>));
    }
}