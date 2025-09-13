using Contracts.Dtos;
using CustomerService.AppService.Commands.AddCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.WebApiApp.Controller;
[Route("api/v1/[controller]")]
[ApiController]
public class CustomerController(IMediator mediator):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(AddCustomerDto addCustomerDto, CancellationToken ct)
    {
        await mediator.Send(new AddCustomerCommand(addCustomerDto), ct);
        return Ok();
    }
}