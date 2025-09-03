using CafeService.AppService.CafeAgg.Commands.AddCafeService.Service;
using CafeService.AppService.CafeAgg.Commands.AddCafeService.Validator;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeService.AppService.StartUpConfiguration;

public static class StartUpConfiguration
{
    public static IServiceCollection AddCafeService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(AddCafeServiceValidator).Assembly);
        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(AddCafeService).Assembly));
        return services;
    }
}