using System.Net;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.Service.Contracts;
using MediatR;

namespace CustomerService.AppService.Commands.AddCustomer;

public class AddCustomerCommandHandler(ICustomerService customerService):IRequestHandler<AddCustomerCommand>
{
    public async Task Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var userId =await  customerService.AddUserIfNotExist(request.CustomerDto, cancellationToken);
        if (userId == null)
            throw CommonExceptionDto.GenerateCommonException("Tell Techniacal Team", (int)HttpStatusCode.BadRequest,
                "userId is null in adding customer");
        await customerService.AddCustomer(request.CustomerDto, (Guid)userId, cancellationToken);
        

    }
}