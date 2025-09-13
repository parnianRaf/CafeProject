using Contracts.RepoContracts;
using CustomerService.AppDomain.CommonEntity;
using Microsoft.EntityFrameworkCore;

namespace CommandRepositories;

public class SqlBaseGenericRepository<T>(IUnitOfWorks unitOfWorks) : ISqlBaseGenericRepository<T> where T : BaseClass
{
    private readonly DbSet<T> _dbSet = unitOfWorks.Set<T>();
    
    public void Create(T entity) =>  _dbSet.Add(entity);

    public void Update(T entity) => _dbSet.Update(entity);
    
    public void Delete(T entity) => _dbSet.Remove(entity);
    
    public void CreateAll(IReadOnlyCollection<T> entities) => _dbSet.AddRange(entities);
    
    public void UpdateAll(IReadOnlyCollection<T> entities) => _dbSet.UpdateRange(entities);
    
    public void DeleteAll(IReadOnlyCollection<T> entities) => _dbSet.RemoveRange(entities);

}