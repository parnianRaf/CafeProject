using CafeFlow.NotifcationService.DataAccess.EmailDetailCollectionAgg;
using CafeFlow.NotifcationService.Domain.Entity;
using CafeFlow.NotifcationService.Domain.Entity.Common;
using Humanizer;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace CafeFlow.NotifcationService.DataAccess.Context;


public class DataBase
{
    private readonly IMongoDatabase _database;

    public DataBase(EmailDetailCollection emailDetailCollection)
    {
        var client = new MongoClient(emailDetailCollection.ConnectionString);
        _database = client.GetDatabase(emailDetailCollection.DatabaseName);

        BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
        {
            cm.AutoMap();
            cm.MapIdProperty(c => c.Id);
        }); 
        BsonClassMap.RegisterClassMap<EmailDetail>(cm =>
        {
            cm.AutoMap();
      
        });
    }

    public IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name.Pluralize());

}