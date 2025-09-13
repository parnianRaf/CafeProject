using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.OrderAgg.Entity;
using CustomerService.AppDomain.OrderProductAgg.Entity;
using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.DecreaseProductToOrder;

public class DecreaseProductToOrderCommandHandler(IRedisCachingService  redisCaching
    ,IProductService productService,ICustomerQueryService customerQueryService
    ,ICafeService cafeService):IRequestHandler<DecreaseProductToOrderCommand>
{
    public async Task Handle(DecreaseProductToOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId =await customerQueryService.GetByUserId(cancellationToken);
        var cafeId = cafeService.GetCafeFromCache(customerId);
        productService.GetProductByCafeId(cafeId, request.OrderProductDto.ProductId ,
            request.OrderProductDto.Quantity,false);
        await redisCaching.DecrementObjectAsync(customerId,typeof(Order),nameof(OrderProduct.ProductId),request.OrderProductDto.Quantity);
    }
}