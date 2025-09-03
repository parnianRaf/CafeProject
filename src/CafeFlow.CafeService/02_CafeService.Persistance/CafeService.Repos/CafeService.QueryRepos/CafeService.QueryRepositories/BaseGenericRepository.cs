using CafeService.AppDomain.CommonEntity;
using CafeService.QueriesDataBase;
using Microsoft.EntityFrameworkCore;

namespace CafeService.QueryRepositories;

public class BaseGenericRepository<T>(CafeDataDbContext context) : IBaseGenericRepository<T> where T :BaseClass
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    
    public virtual  IQueryable<T> GetAll()
    {
        return  _dbSet;
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    


}