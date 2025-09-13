using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.OrderAgg.Entity;
using CustomerService.AppDomain.OrderProductAgg.Entity;
using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.AddProductToOrder;

public class AddProductToOrderCommandHandler(IRedisCachingService redisCaching , 
    IProductService productService,ICustomerQueryService customerQueryService
        ,ICafeService cafeService):IRequestHandler<AddProductToOrderCommand>
{
    public async Task Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId =await customerQueryService.GetByUserId(cancellationToken);
        var cafeId = cafeService.GetCafeFromCache(customerId); 
        productService.GetProductByCafeId(cafeId, request.OrderProductDto.ProductId , request.OrderProductDto.Quantity,true);
        await redisCaching.AddToObjectAsync(customerId,typeof(Order),nameof(OrderProduct.ProductId),request.OrderProductDto.Quantity);
    }
}