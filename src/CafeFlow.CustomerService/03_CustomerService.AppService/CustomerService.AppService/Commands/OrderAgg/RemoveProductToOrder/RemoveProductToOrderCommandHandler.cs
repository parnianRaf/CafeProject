using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.OrderAgg.Entity;
using CustomerService.AppDomain.OrderProductAgg.Entity;
using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.RemoveProductToOrder;

public class RemoveProductToOrderCommandHandler(ICustomerQueryService customerQueryService , IProductService productService
,IRedisCachingService redisCaching ,ICafeService cafeService ):IRequestHandler<RemoveProductToOrderCommand>
{
    public async Task Handle(RemoveProductToOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId =await customerQueryService.GetByUserId(cancellationToken);
        var cafeId = cafeService.GetCafeFromCache(customerId);
        productService.GetProductByCafeId(cafeId, request.ProductId ,
            null,false);
        await redisCaching.RemoveFromObjectAsync(customerId,typeof(Order),nameof(OrderProduct.ProductId));
    }
}