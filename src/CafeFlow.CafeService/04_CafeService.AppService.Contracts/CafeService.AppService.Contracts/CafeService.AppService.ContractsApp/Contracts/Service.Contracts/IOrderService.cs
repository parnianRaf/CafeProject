using CafeService.AppDomain.OrderAgg.Entity;
using CafeService.FrameWorks.Dto.RequestDtos;

namespace CafeService.AppService.OrderAgg.Service;

public interface IOrderService
{
    Order AddOrder(OrderDto orderDto);
}