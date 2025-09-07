using CafeFlow.AuthenticationService.AppService.Contracts.Interface;
using CafeFlow.AuthenticationService.AppService.UserAgg.LogIn.Service;
using CafeFlow.AuthenticationService.AppService.UserAgg.LogIn.Validator;
using CafeFlow.AuthenticationService.AppService.UserAgg.Register.Service;
using CafeFlow.AuthenticationService.AppService.UserAgg.Register.Validator;
using CafeFlow.AuthenticationService.DataAccess;
using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.AuthenticationService.Extensions;
using CafeFlow.Framework.AthenticationToken.Extensions;
using CafeFlow.Framework.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CafeFlow.AuthenticationService.Configuration.StartUpConfiguration;

public static class InitialConfiguration
{
    public static IServiceCollection AddInitialConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddScoped<IUserLogInService, UserLogInService>();
        services.AddScoped<IUserRegisterService, UserRegisterService>();

        services.AddValidatorsFromAssemblyContaining<UserLogInValidator>();
        services.AddValidatorsFromAssemblyContaining<UserRegisterValidator>();


        
        services.AddDbContext<UserDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("AuthenticationConnection")));
        
        
        services.AddHttpClient("NotificationService", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5042"); 
            client.Timeout = TimeSpan.FromMinutes(10); 
        });
        
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<UserDbContext>()
        .AddErrorDescriber<PersianIdentityErrorDescriber>();
        

        return services;
    }
}