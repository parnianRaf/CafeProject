using CustomerService.AppService.Queries.CafeAgg.GetAllCafe;
using CustomerService.AppService.Queries.CafeAgg.GetCafeTables;
using CustomerService.AppService.Queries.CafeAgg.ScanCafe;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.WebApiApp.Controller;

[Route("api/v1/[controller]")]
[ApiController]
public class CafeController(IMediator mediator): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var cafeList =await mediator.Send(new GetAllCafeQuery(), ct);
        return Ok(cafeList);
    }

    [HttpGet(nameof(GetTables))]
    public async Task<IActionResult> GetTables(string cafeId , CancellationToken ct)
    {
        var cafeTables = await mediator.Send(new GetCafeTablesQuery(cafeId),ct);
        return Ok(cafeTables);
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> ScanCafe(string cafeId, string cafeTableId,CancellationToken ct)
    {
        await mediator.Send(new ScanCafeQuery(cafeId,cafeTableId), ct);
        return Ok();
    }
    
    
}