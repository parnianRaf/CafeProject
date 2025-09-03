using CafeService.AppDomain.CommonEntity;

namespace CafeService.QueryRepositories;

public interface IBaseGenericRepository<T> where T : BaseClass
{
    IQueryable<T> GetAll();
    Task<T?> GetById(Guid id);
}