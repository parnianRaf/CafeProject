using Contracts.Dtos;
using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.DecreaseProductToOrder;

public record DecreaseProductToOrderCommand(OrderProductDto OrderProductDto):IRequest;