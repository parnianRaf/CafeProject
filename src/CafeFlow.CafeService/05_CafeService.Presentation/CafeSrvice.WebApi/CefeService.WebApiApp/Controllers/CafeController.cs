using CafeService.AppService.CafeAgg.Commands.AddCafeService.Service;
using CafeService.AppService.CafeAgg.Queries;
using CafeService.FrameWorks.Dto.CafeAggDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefeService.WebApiApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CafeController(IMediator mediator ):ControllerBase
{
    [HttpPost(nameof(AddCafeService))]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCafe(AddCafeDto cafeDto , CancellationToken ct )
    {
        var result = await mediator.Send(new AddCafeService(cafeDto) , ct);
        return result.IsValid ? Ok(result) : BadRequest(result);
    }

    [HttpGet(nameof(GetAllCafeNames))]
    public async Task<IActionResult> GetAllCafeNames(CancellationToken ct)
    {
        var result = await mediator.Send(new GetCafeNameService(), ct);
        return Ok(result);
    }
}