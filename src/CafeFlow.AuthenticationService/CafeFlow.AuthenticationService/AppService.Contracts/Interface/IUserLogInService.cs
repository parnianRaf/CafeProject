using CafeFlow.AuthenticationService.AppService.Contracts.Dto;

namespace CafeFlow.AuthenticationService.AppService.Contracts.Interface;

public interface IUserLogInService
{
    Task<string> LogIn(UserLogInDto userLogInDto);
}