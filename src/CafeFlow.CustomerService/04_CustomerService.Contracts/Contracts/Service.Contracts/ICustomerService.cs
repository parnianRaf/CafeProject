using Contracts.Dtos;

namespace Contracts.Service.Contracts;

public interface ICustomerService
{
    Task<Guid?> AddUserIfNotExist(AddCustomerDto  addCustomerDto , CancellationToken ct);
    Task AddCustomer(AddCustomerDto addCustomerDto, Guid userId, CancellationToken ct);
}