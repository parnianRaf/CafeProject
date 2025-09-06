using CafeService.AppDomain.CommonEntity;
using Microsoft.EntityFrameworkCore;

namespace CafeService.FrameWorks.Contracts.Repository.Contracts;

public interface IUnitOfWorks
{
    DbSet<T> Set<T>() where T : BaseClass;
    void Dispose();
    Task SaveChangesAsync();
}