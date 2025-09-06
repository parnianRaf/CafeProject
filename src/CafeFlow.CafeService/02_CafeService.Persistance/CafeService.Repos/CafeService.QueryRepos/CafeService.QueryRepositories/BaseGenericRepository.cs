using CafeService.AppDomain.CommonEntity;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.QueriesDataBase;
using Microsoft.EntityFrameworkCore;

namespace CafeService.QueryRepositories;

public class BaseGenericRepository<T>(CafeDataDbContext context) : IBaseGenericRepository<T> where T :BaseClass
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    
    public async Task<T?> GetAsync(Guid id)
    {
        var entity =await  _dbSet.FindAsync(id);
        return entity;
    }

    
    // it shouldn't be used because it is sync
    public async  Task<IQueryable<T>?> GetAllAsync()
    {
        return await Task.FromResult(_dbSet.AsQueryable());
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }
    
    


}