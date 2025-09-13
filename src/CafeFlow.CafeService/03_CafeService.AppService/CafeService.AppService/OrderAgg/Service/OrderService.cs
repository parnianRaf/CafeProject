using CafeService.AppDomain.OrderAgg.Entity;
using CafeService.AppDomain.OrderProductAgg.Entity;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Dto.RequestDtos;

namespace CafeService.AppService.OrderAgg.Service;

public class OrderService(ISqlBaseGenericRepository<Order> orderRepository,
    ISqlBaseGenericRepository<OrderProduct> orderProductRepository) : IOrderService
{
    public Order AddOrder(OrderDto orderDto)
    {
        var orderEntity =Order.Create(orderDto.CafeId ,orderDto.CafeTableId , orderDto.CustomerId); 
        orderRepository.Create(orderEntity);
        var orderProducts = AddOrderProducts(orderDto.OrderProductDtos , orderEntity.Id);
        orderProductRepository.AddRange(orderProducts);
        return orderEntity;
    }
    
    private List<OrderProduct> AddOrderProducts(List<OrderProductDto> orderProductDto, string orderId)
    {
        var orderProducts = new List<OrderProduct>();
        orderProductDto.ForEach(orderPr =>
        {
            orderProducts.Add(OrderProduct.Create(orderPr.ProductId,orderId,orderPr.OrderUnitPrice,orderPr.OrderNumber));
        });
        return orderProducts;
    }
}