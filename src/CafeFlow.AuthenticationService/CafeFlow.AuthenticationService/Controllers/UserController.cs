using Microsoft.AspNetCore.Mvc;
using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using CafeFlow.AuthenticationService.AppService.Contracts.Interface;

namespace CafeFlow.AuthenticationService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserRegisterService userRegisterService , IUserLogInService userLogInService) :ControllerBase
{
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
    {
        var result = await userRegisterService.Register(userRegisterDto);

        if (result.Any())
        {
          return BadRequest(string.Join(",",result.Select(x=>x.Description)));
        }

        return Ok(result);
    }

    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(UserLogInDto userLogInDto)
    {
        var result = await userLogInService.LogIn(userLogInDto);
        return Ok(result);
    }
}