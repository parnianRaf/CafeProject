using CafeService.AppDomain.CommonEntity;

namespace CafeService.FrameWorks.Contracts.Repository.Contracts;

public interface IBaseGenericRepository<T> where T : BaseClass
{
    IQueryable<T> GetAll();
    Task<T?> GetAsync(Guid id);
    Task<IQueryable<T>?> GetAllAsync();
}