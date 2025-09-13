using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.RepoContracts;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.OrderAgg.Entity;
using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.SubmitOrder;

public class SubmitOrderCommandHandler( IRedisCachingService redisCaching,IOrderService orderService,
    ICafeService cafeService,ICafeServiceOrder  cafeServiceOrder,
    ICustomerQueryService customerQueryService,IUnitOfWorks unitOfWorks):IRequestHandler<SubmitOrderCommand>
{
    public async Task Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId =await customerQueryService.GetByUserId(cancellationToken);
        var cafeId = cafeService.GetCafeFromCache(customerId);
        var cafeTableId = cafeService.GetCafeTableFromCache(customerId);
        
        // order dar hamin service ijad shavad vali locally save nashavad 
        var order = await orderService.AddOrder(customerId,cafeId,cafeTableId);
        
        
        
        //sepes order dar cafeservice ijad shavad
        var result =await cafeServiceOrder.PostOrder(order);
        if (!result?.IsSuccessStatusCode ?? true)
        {
           throw CommonExceptionDto.GenerateCommonException(result?.Message ?? "An error occured");
        }
        
        await unitOfWorks.SaveChangesAsync(cancellationToken);
        await redisCaching.ClearObjectAsync(customerId,typeof(Order));
        
    }
}