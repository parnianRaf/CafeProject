using FluentValidation;
using Microsoft.AspNetCore.Identity;
using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.AuthenticationService.AppService.Contracts.Interface;

namespace CafeFlow.AuthenticationService.AppService.UserAgg.Register.Service;

public class UserRegisterService(UserManager<User> userManager , IValidator<UserRegisterDto> validator) : IUserRegisterService
{
    public async Task<List<IdentityError>> Register(UserRegisterDto userRegisterDto)
    {
       // await Validate(userRegisterDto);
        var user = User.GenerateUser(userRegisterDto.FirstName!, userRegisterDto.LastName!,  userRegisterDto.UserName!);
        var result =  await userManager.CreateAsync(user, userRegisterDto.Password!);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, userRegisterDto.UserRole.ToString());
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
    
    
}