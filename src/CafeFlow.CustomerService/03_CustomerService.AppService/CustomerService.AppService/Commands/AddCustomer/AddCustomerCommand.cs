using Contracts.Dtos;
using MediatR;

namespace CustomerService.AppService.Commands.AddCustomer;

public record AddCustomerCommand(AddCustomerDto CustomerDto):IRequest;