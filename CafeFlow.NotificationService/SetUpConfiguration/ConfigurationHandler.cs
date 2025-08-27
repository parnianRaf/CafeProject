using CafeFlow.NotifcationService.AppService.Contracts.Interfaces;
using CafeFlow.NotifcationService.AppService.EmailAgg.Validate;
using CafeFlow.NotifcationService.AppService.EmialDetailAgg.Service;
using CafeFlow.NotifcationService.AppSettingEntity;
using CafeFlow.NotifcationService.DataAccess.Context;
using CafeFlow.NotifcationService.DataAccess.EmailDetailCollectionAgg;
using CafeFlow.NotifcationService.DataAccess.Repo;
using CafeFlow.NotifcationService.Domain.Entity;
using CafeFlow.NotificationService.AppService.EmailAgg.Service;
using FluentValidation;

namespace CafeFlow.NotifcationService.SetUpConfiguration;

public static class ConfigurationHandler
{
    public static IServiceCollection AddConfigurationHandler(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(typeof(EmailServiceDtoValidate).Assembly);
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IAddEmailDetail , AddEmailDetail>();
        services.AddScoped(typeof(IEntityDetailRepo<>), typeof(EntityDetailRepo<>));
        services.AddSingleton<DataBase>();
        services.AddSingleton<EmailConfiguration>(_ => configuration
        .GetSection("EmailConfiguration").Get<EmailConfiguration>()!);
        services.AddSingleton<EmailDetailCollection>(_ => configuration
        .GetSection("EmailDetailCollection").Get<EmailDetailCollection>()!);
        return services;
    }
}