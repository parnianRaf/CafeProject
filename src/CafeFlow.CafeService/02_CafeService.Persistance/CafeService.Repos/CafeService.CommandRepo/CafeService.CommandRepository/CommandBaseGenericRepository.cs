using CafeService.AppDomain.CommonEntity;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.MongoDbApp;
using CafeService.MongoDbApp.Context;
using MongoDB.Driver;

namespace CafeService.CommandRepository;

public class CommandBaseGenericRepository<T>(MongoDb mongoDb) : ICommandBaseGenericRepository<T> where T : BaseClass
{
    private IMongoCollection<T> _collection = mongoDb.GetCollection<T>();
    
    public virtual async Task<T> Create(T entity )
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public virtual async Task<IEnumerable<T>> CreateMany(IReadOnlyCollection<T>  entities)
    {
        await _collection.InsertManyAsync(entities);
        return entities;
    }

    public virtual async Task<T> UpdateAsync(string id ,  T entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == id, entity);
        return entity;
    }

    public virtual async Task Delete(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }


}