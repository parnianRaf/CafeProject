using CafeService.SqlCommandDataBase.Context;
using Contracts.RepoContracts;
using CustomerService.AppDomain.CommonEntity;
using Microsoft.EntityFrameworkCore;

namespace CommandRepositories;

public class UnitOfWorks(CustomerDbContext dbContext) : IUnitOfWorks
{
    public DbSet<T> Set<T>() where T : BaseClass
    {
        return dbContext.Set<T>();
    }
    

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}