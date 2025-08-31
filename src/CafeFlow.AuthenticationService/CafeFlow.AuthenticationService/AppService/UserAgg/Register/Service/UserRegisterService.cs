using System.Text;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.AuthenticationService.AppService.Contracts.Interface;
using CafeFlow.Framework.LogAgg.Log.Contracts;

namespace CafeFlow.AuthenticationService.AppService.UserAgg.Register.Service;

public class UserRegisterService(UserManager<User> userManager , IValidator<UserRegisterDto> validator, 
    IHttpClientFactory httpClientFactory , ILogService logService) : IUserRegisterService
{
    public async Task<List<IdentityError>> Register(UserRegisterDto userRegisterDto)
    {
       // await Validate(userRegisterDto);
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
            await SendWelcomeEmail(user.Email! , "Welcome" , "Welcome to the app");
        }

        return (List<IdentityError>)result.Errors;
    }

    private async Task Validate(UserRegisterDto userRegisterDto)
    {
        await validator.ValidateAndThrowAsync(userRegisterDto);
        var user = await userManager.FindByNameAsync(userRegisterDto.UserName!);
        if(user is not null)
            throw new  ValidationException("Username already exists.");
    }

    private async Task<bool> SendWelcomeEmail(string emailTo , string subject , string message)
    {
        var client = httpClientFactory.CreateClient("NotificationService");
        var content = new {Subject =subject , Body = message , EmailTo = emailTo};
        var contentJson = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/Notification/Email", contentJson);
        if(!response.IsSuccessStatusCode)
            logService.LogError($"Error sending email to {emailTo}");
        return response.IsSuccessStatusCode;
    }
    
    
}