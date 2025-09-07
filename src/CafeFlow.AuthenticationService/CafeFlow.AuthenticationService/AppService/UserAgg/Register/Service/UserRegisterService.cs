using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.AuthenticationService.AppService.Contracts.Interface;
using CafeFlow.Framework.ExceptionAgg.Exception;
using CafeFlow.Framework.LogAgg.Log.Contracts;
using CafeFlow.Framework.Provider.Notification.Service.Contracts;

namespace CafeFlow.AuthenticationService.AppService.UserAgg.Register.Service;

public class UserRegisterService(UserManager<User> userManager , IValidator<UserRegisterDto> validator, 
    ILogService logService , INotificationService notificationService) : IUserRegisterService
{
    public async Task<List<IdentityError>> Register(UserRegisterDto userRegisterDto , CancellationToken ct)
    {
        await Validate(userRegisterDto);
        var user = User.GenerateUser(userRegisterDto.FirstName!, userRegisterDto.LastName!,  userRegisterDto.UserName! , userRegisterDto.Email!);
        var result =  await userManager.CreateAsync(user, userRegisterDto.Password!);

        if (result.Succeeded)
        {
            logService.LogInformation($"User {user.UserName} created successfully");
            result = await userManager.AddToRoleAsync(user, userRegisterDto.UserRole.ToString());
        }

        if (result.Succeeded)
        {
            logService.LogInformation($"Role {userRegisterDto.UserRole.ToString()} has been add to  User {user.UserName} ");
            var emilSendResult = await notificationService.SendEmail(user.Email! , "Welcome" , "Welcome to the app" , ct);
            if(!emilSendResult.IsValid)
                 logService.LogError($"Error sending email to {user.Email} : detail:{emilSendResult.Message}");
                
        }

        return (List<IdentityError>)result.Errors;
    }

    private async Task Validate(UserRegisterDto userRegisterDto)
    {
        await validator.ValidateAndThrowAsync(userRegisterDto);
        var user = await userManager.FindByNameAsync(userRegisterDto.UserName!);
        if(user is not null)
            throw  CommonExceptionDto.GenerateCommonException("Username already exists.");
    }


    
    
}