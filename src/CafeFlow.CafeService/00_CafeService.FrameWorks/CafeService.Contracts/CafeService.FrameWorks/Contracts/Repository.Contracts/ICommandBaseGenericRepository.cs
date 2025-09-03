using CafeService.AppDomain.CommonEntity;

namespace CafeService.FrameWorks.Contracts.Repository.Contracts;

public interface ICommandBaseGenericRepository<T> where T : BaseClass
{
    Task<T> Create(T entity );
    Task<IEnumerable<T>> CreateMany(IReadOnlyCollection<T>  entities);
    Task<T> UpdateAsync(string id ,  T entity);
    Task Delete(string id);
}