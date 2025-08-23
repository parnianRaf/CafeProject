using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using Microsoft.AspNetCore.Identity;

namespace CafeFlow.AuthenticationService.AppService.Contracts.Interface;

public interface IUserRegisterService
{
    Task<List<IdentityError>> Register(UserRegisterDto userRegisterDto);

}