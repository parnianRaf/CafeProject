using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Microsoft.AspNetCore.Identity;

namespace CafeFlow.AuthenticationService.AppService.Contracts.Interface;

public interface IUserRegisterService
{
    Task<Guid> Register(UserRegisterDto userRegisterDto, CancellationToken ct);
    Task<Guid> RegisterCustomerUserIfNotExists(UserRegisterDto userRegisterDto, CancellationToken ct);

}