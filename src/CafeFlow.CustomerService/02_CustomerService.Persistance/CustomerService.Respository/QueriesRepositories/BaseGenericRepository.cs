using Contracts.RepoContracts;
using CustomerService.AppDomain.CommonEntity;
using CustomerService.QueriesDataBase;
using Microsoft.EntityFrameworkCore;

namespace QueriesRepositories;

public class BaseGenericRepository<T>(CustomerDataDbContext context) : IBaseGenericRepository<T> where T :BaseClass
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    
    public async Task<T?> GetAsync(string id)
    {
        var entity =await  _dbSet.FindAsync(id);
        return entity;
    }

    


    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }
    
    


}