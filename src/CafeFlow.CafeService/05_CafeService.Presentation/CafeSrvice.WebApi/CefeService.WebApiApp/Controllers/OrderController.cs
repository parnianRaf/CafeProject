using CafeService.AppService.OrderAgg.Command.TakeOrder;
using CafeService.FrameWorks.Dto.RequestDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CefeService.WebApiApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController(IMediator mediator):ControllerBase
{
    [HttpPost(nameof(TakeOrder))]
    public async Task<IActionResult> TakeOrder(OrderDto  orderDto, CancellationToken ct)
    {
        var result = await mediator.Send(new TakeOrderCommand(orderDto), ct);
        return Ok(result);
    }
}