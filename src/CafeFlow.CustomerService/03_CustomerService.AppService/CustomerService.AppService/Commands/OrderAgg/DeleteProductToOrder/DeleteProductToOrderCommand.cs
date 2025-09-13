using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.DeleteProductToOrder;

public record DeleteProductToOrderCommand():IRequest;