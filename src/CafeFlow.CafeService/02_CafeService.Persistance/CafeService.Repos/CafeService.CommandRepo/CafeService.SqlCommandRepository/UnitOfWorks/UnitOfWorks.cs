using CafeService.AppDomain.CommonEntity;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.SqlServerDataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace CafeService.SqlCommandRepository.UnitOfWorks;

public class UnitOfWorks(CafeDbContext dbContext) : IUnitOfWorks
{
    public DbSet<T> Set<T>() where T : BaseClass
    {
        return dbContext.Set<T>();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}