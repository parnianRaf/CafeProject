using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.QueriesDataBase.Configuration;

public static class StartUpConfiguration
{
    public static void StartUpSqlDbConfiguration(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<CafeDataDbContext>(opt => opt.UseSqlServer(configuration["CafeSqlConnection:DefaultConnection"]));

    }
}