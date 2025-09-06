using FluentValidation;
using System.Security.Claims;
using Exception = System.Exception;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.AuthenticationService.AppService.Contracts.Interface;
using CafeFlow.Framework.AthenticationToken.Extensions;
using CafeFlow.Framework.ExceptionAgg.Exception;

namespace CafeFlow.AuthenticationService.AppService.UserAgg.LogIn.Service;

public class UserLogInService( SignInManager<User> signInManager,IValidator<UserLogInDto> validator ,ConfigurationEntity configurationEntity) : IUserLogInService
{
    public async Task<string> LogIn(UserLogInDto userLogInDto)
    {
        await validator.ValidateAndThrowAsync(userLogInDto);
        var user =await signInManager.UserManager.FindByNameAsync(userLogInDto.UserName!);

        if (user is null)
            throw CommonExceptionDto.GenerateCommonException("username not found",(int)HttpStatusCode.NotFound);
        
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
            new Claim(ClaimTypes.Name , user.UserName!)
        };
        roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));
        
        var key = configurationEntity.SecurityKey;
        var cred = configurationEntity.SigningCredentials;
        var token = new JwtSecurityToken(
            issuer: configurationEntity.Issuer,
            audience: configurationEntity.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: cred);
        return  new JwtSecurityTokenHandler().WriteToken(token);
    }
}