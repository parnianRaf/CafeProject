
using CustomerService.AppDomain.CommonEntity;

namespace Contracts.RepoContracts;

public interface ISqlBaseGenericRepository<T> where T : BaseClass
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    void CreateAll(IReadOnlyCollection<T> entities);
    void UpdateAll(IReadOnlyCollection<T> entities);
    void DeleteAll(IReadOnlyCollection<T> entities);
}