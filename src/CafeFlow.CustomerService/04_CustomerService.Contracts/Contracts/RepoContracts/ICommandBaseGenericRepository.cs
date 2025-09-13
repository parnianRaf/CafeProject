
using CustomerService.AppDomain.CommonEntity;

namespace Contracts.RepoContracts;

public interface IMongoCommandBaseGenericRepository<T> where T : BaseClass
{
    Task<T> Create(T entity );
    Task<IEnumerable<T>> CreateMany(IReadOnlyCollection<T>  entities);
    Task<T> UpdateAsync(string id ,  T entity);
    Task Delete(string id);
}