using CafeFlow.Framework.Caching.Service.Contracts;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.OrderAgg.Entity;
using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.DeleteProductToOrder;

public class DeleteProductToOrderCommandHandler(ICustomerQueryService customerQueryService , IRedisCachingService redisCaching):IRequestHandler<DeleteProductToOrderCommand>
{
    public async Task Handle(DeleteProductToOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId =await customerQueryService.GetByUserId(cancellationToken);
        await redisCaching.ClearObjectAsync(customerId,typeof(Order));
    }
}