using FluentValidation;
using System.Security.Claims;
using Exception = System.Exception;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.AuthenticationService.Configuration.Extensions;
using CafeFlow.AuthenticationService.AppService.Contracts.Interface;

namespace CafeFlow.AuthenticationService.AppService.UserAgg.LogIn.Service;

public class UserLogInService( SignInManager<User> signInManager,IValidator<UserLogInDto> validator) : IUserLogInService
{
    public async Task<string> LogIn(UserLogInDto userLogInDto)
    {
        await validator.ValidateAndThrowAsync(userLogInDto);
        var user =await signInManager.UserManager.FindByNameAsync(userLogInDto.UserName!);

        if (user is null)
            throw new Exception("username not found");
        
        var result =await signInManager.PasswordSignInAsync(user!, userLogInDto.Password!,true,false);
        if (result.Succeeded)
        {
            var role =await signInManager.UserManager.GetRolesAsync(user);
            return GenerateToken(user , role);
        }
        
        return "UserName or Password is incorrect";
    }

    private string GenerateToken(User user , IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name , user.UserName!),
        };
        roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));
        
        var key = ConfigurationEntity.SecurityKey;
        var cred = ConfigurationEntity.SigningCredentials;
        var token = new JwtSecurityToken(
            issuer: ConfigurationEntity.Issuer,
            audience: ConfigurationEntity.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(7),
            signingCredentials: cred);
        return  new JwtSecurityTokenHandler().WriteToken(token);
    }
}