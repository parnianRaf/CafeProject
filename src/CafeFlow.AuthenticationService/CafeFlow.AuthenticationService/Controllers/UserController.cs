using Microsoft.AspNetCore.Mvc;
using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.AuthenticationService.AppService.Contracts.Interface;

namespace CafeFlow.AuthenticationService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserRegisterService userRegisterService , IUserLogInService userLogInService) :ControllerBase
{
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto , CancellationToken ct)
    {
        var result = await userRegisterService.Register(userRegisterDto , ct);
        return Ok(result);
    }

    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(UserLogInDto userLogInDto)
    {
        var result = await userLogInService.LogIn(userLogInDto);
        return Ok(result);
    }

    public async Task<IActionResult> RegisterCustomerUserIfNotExists([FromBody] UserRegisterDto userRegisterDto , CancellationToken ct)
    {
        var result = await userRegisterService.RegisterCustomerUserIfNotExists(userRegisterDto, ct);
        return Ok(result);
    }
    
    
}