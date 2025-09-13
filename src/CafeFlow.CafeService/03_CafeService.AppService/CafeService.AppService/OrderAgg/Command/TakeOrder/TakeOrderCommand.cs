using CafeFlow.Framework.CommonDtos.ResultDtos;
using CafeService.FrameWorks.Dto.RequestDtos;
using MediatR;

namespace CafeService.AppService.OrderAgg.Command.TakeOrder;

public record TakeOrderCommand(OrderDto AddOrderDto):IRequest<OutputApiResult>;