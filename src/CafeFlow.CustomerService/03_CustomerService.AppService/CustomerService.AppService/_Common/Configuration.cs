using Contracts.Service.Contracts;
using CustomerService.AppService.Commands.AddCustomer;
using CustomerService.AppService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.AppService._Common;

public static class Configuration
{
    public static IServiceCollection AppServiceConfigure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<CustomerCommandService>(opt =>
        {
            opt.BaseAddress = new Uri(configuration["UserService:AuthenticationServiceAddress"]!);
        });
        services.AddMediatR(opt => 
            opt.RegisterServicesFromAssembly(typeof(AddCustomerCommand).Assembly));
        services.AddHttpContextAccessor();
        services.AddScoped<ICustomerService, CustomerCommandService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICustomerQueryService ,CustomerQueryService>();
        services.AddScoped<ICafeService, CafeService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddHttpClient<CafeServiceOrder>(opt =>
        {
            opt.BaseAddress = new Uri(configuration["UserService:CafeServiceAddress"]!);
        });
        services.AddScoped<ICafeServiceOrder, CafeServiceOrder>();
        return services;
    }
}