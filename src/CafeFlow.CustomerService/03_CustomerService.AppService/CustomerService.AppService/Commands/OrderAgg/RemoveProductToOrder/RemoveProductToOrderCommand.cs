using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.RemoveProductToOrder;

public record RemoveProductToOrderCommand(string? ProductId):IRequest;