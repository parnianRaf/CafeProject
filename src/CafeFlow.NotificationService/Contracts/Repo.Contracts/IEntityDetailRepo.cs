using CafeFlow.NotifcationService.Domain.Entity.Common;

namespace CafeFlow.NotifcationService.Contracts.Repo.Contracts;

public interface IEntityDetailRepo<T> where T : BaseEntity
{
    Task Create(T entity);
    Task Update(string id , T entity);
    Task Delete(string id);
    Task<T> GetById(string id);
    Task<IEnumerable<T>> GetAll();
}