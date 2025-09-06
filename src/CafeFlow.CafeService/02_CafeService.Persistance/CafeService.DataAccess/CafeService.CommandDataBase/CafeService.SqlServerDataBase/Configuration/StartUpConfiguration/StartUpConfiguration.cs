using CafeService.SqlServerDataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.SqlServerDataBase.Configuration.StartUpConfiguration;

public static class StartUpConfiguration
{
    public static IServiceCollection ConfigureSqlServerDataBase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CafeDbContext>(opt => 
            opt.UseSqlServer(configuration["CafeSqlConnection:CommandConnection"]));
        return services;
    }
}