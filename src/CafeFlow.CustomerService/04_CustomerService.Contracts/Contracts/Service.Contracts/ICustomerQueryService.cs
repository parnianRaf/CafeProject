namespace Contracts.Service.Contracts;

public interface ICustomerQueryService
{
    Task<string?> GetByUserId(Guid userId, CancellationToken ct);
    Task<string> GetByUserId(CancellationToken cancellationToken);
}