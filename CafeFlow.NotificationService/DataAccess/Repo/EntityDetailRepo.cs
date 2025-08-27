using CafeFlow.NotifcationService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using CafeFlow.NotifcationService.DataAccess.Context;
using CafeFlow.NotifcationService.Domain.Entity.Common;
using MongoDB.Entities;


namespace CafeFlow.NotifcationService.DataAccess.Repo;

public class EntityDetailRepo<T> : IEntityDetailRepo<T> where T:BaseEntity
{

    private readonly DataBase _dataBase;
    private readonly IMongoCollection<T> _mongoCollection;

    public EntityDetailRepo(DataBase dataBase)
    {
         _dataBase = dataBase;
         _mongoCollection = _dataBase.GetCollection<T>();
    }

    public async Task Create(T entity)
    {
        await _mongoCollection.InsertOneAsync(entity);
    }

    public async Task Update(string id , T entity)
    {
        await _mongoCollection.ReplaceOneAsync(x => x.Id == id, entity);
    }

    public async Task Delete(string id)
    {
        await _mongoCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<T> GetById(string id)
    {
        return await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _mongoCollection.Find(x => true).ToListAsync();
    }

}