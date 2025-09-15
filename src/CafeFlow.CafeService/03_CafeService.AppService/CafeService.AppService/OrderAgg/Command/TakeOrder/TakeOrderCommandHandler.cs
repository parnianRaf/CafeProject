using System.Net;
using CafeFlow.Framework.CommonDtos.ResultDtos;
using CafeService.AppService.OrderAgg.Service;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Contracts.Service.Contracts;
using MediatR;

namespace CafeService.AppService.OrderAgg.Command.TakeOrder;

public class TakeOrderCommandHandler(IOrderService orderService,IInventoryQueryService inventoryQueryService,
            IInventoryCommandService inventoryCommandService,
            IUnitOfWorks unitOfWorks):IRequestHandler<TakeOrderCommand, OutputApiResult>
{
    public async Task<OutputApiResult> Handle(TakeOrderCommand request, CancellationToken cancellationToken)
    {

        var hasInventory = await inventoryQueryService.HasInventory(request.AddOrderDto);
        if (!hasInventory.IsSuccess)
            return OutputApiResult.GenerateOutputApiResult((int)HttpStatusCode.BadRequest,
                hasInventory.Result?.ToString());

        var cafeProducts = 
            await inventoryQueryService.GetAllCafeProducts(request.AddOrderDto);
        
        inventoryCommandService.UpdateInventory(cafeProducts, request.AddOrderDto.OrderProductDtos);

        orderService.AddOrder(request.AddOrderDto);
        await unitOfWorks.SaveChangesAsync(cancellationToken);
        
        return OutputApiResult.GenerateOutputApiResult((int)HttpStatusCode.OK,"Successfully Added");

    }
}