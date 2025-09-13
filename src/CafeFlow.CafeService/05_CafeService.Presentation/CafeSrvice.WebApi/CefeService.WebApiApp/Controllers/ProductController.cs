using CafeFlow.Framework.CommonDtos.ResultDtos;
using CafeService.AppService.ProductAgg.Commands.AddProductAgg.Service;
using CafeService.FrameWorks.Dto.ProductAggDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefeService.WebApiApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator):ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(AddProductDto productDto , CancellationToken ct)
    {
        var result = await mediator.Send(new AddProductCommand(productDto), ct);
        return Ok(OutputApiResult.GenerateOutputApiResult(result));
    }
}