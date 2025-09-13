using Contracts.Dtos;
using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.AddProductToOrder;

public record AddProductToOrderCommand(OrderProductDto OrderProductDto) : IRequest;
