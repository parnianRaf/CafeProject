using CafeService.SqlCommandDataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.SqlCommandDataBase._Common.StartUpConfiguration;

public static class StartUpConfiguration
{
    public static IServiceCollection ConfigureSqlServerDataBase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CustomerDbContext>(opt => 
            opt.UseSqlServer(configuration["CustomerSqlConnection:CommandConnection"]));
        services.AddHttpContextAccessor();
        return services;
    }
}