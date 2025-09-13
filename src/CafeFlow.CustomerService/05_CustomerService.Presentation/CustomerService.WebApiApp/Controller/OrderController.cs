using Contracts.Dtos;
using CustomerService.AppService.Commands.OrderAgg.AddProductToOrder;
using CustomerService.AppService.Commands.OrderAgg.DecreaseProductToOrder;
using CustomerService.AppService.Commands.OrderAgg.DeleteProductToOrder;
using CustomerService.AppService.Commands.OrderAgg.RemoveProductToOrder;
using CustomerService.AppService.Commands.OrderAgg.SubmitOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.WebApiApp.Controller;
[Route("api/v1/[controller]")]
[ApiController]
[Authorize(Roles = "Customer")]
public class OrderController(IMediator mediator):ControllerBase
{
    
    [HttpPost(nameof(AddProductOrder))]
    public async Task<IActionResult> AddProductOrder(OrderProductDto orderProduct, CancellationToken ct)
    {
        await mediator.Send(new AddProductToOrderCommand(orderProduct), ct);
        return Ok();
    }
    
    [HttpPost(nameof(DecreaseProductOrder))]
    public async Task<IActionResult> DecreaseProductOrder(OrderProductDto orderProduct, CancellationToken ct)
    {
        await mediator.Send(new DecreaseProductToOrderCommand(orderProduct), ct);
        return Ok();
    }
    
    
    [HttpPost(nameof(RemoveProductOrder))]
    public async Task<IActionResult> RemoveProductOrder(string? productId, CancellationToken ct)
    {
        await mediator.Send(new RemoveProductToOrderCommand(productId), ct);
        return Ok();
    } 
    
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder(CancellationToken ct)
    {
        await mediator.Send(new DeleteProductToOrderCommand(), ct);
        return Ok();
    }
    
    [HttpPost(nameof(SubmitOrders))]
    public async Task<IActionResult> SubmitOrders(CancellationToken ct)
    {
        await mediator.Send(new SubmitOrderCommand(), ct);
        return Ok();
    }


    
}