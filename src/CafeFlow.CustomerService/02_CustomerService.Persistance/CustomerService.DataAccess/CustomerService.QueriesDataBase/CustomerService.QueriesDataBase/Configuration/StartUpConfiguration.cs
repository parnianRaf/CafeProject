using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.QueriesDataBase.Configuration;

public static class StartUpConfiguration
{
    public static void StartUpSqlDbConfiguration(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<CustomerDataDbContext>(opt => 
            opt.UseSqlServer(configuration["CustomerSqlConnection:DefaultConnection"]));

    }
}