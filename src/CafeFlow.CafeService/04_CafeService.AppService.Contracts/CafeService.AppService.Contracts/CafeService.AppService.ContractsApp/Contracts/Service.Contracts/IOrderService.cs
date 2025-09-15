using CafeService.AppDomain.OrderAgg.Entity;
using CafeService.FrameWorks.Dto.RequestDtos;

namespace CafeService.FrameWorks.Contracts.Service.Contracts;

public interface IOrderService
{
    Order AddOrder(OrderDto orderDto);
}