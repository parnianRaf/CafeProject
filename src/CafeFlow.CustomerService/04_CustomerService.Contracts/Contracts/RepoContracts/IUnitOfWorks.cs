using CustomerService.AppDomain.CommonEntity;
using Microsoft.EntityFrameworkCore;

namespace Contracts.RepoContracts;

public interface IUnitOfWorks
{
    DbSet<T> Set<T>() where T : BaseClass;
    void Dispose();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}