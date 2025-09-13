
using CustomerService.AppDomain.CommonEntity;

namespace Contracts.RepoContracts;

public interface IBaseGenericRepository<T> where T : BaseClass
{
    IQueryable<T> GetAll();
    Task<T?> GetAsync(string id);
}