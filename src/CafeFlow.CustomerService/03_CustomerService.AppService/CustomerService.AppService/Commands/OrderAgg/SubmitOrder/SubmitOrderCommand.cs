using MediatR;

namespace CustomerService.AppService.Commands.OrderAgg.SubmitOrder;

public record SubmitOrderCommand:IRequest;