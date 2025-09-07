
using Humanizer;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CafeService.MongoDbApp.Context;

public class MongoDb(IConfiguration configuration)
{
    private readonly IMongoDatabase _mongoDatabase = 
        new MongoClient(configuration["MongoDb:ConnectionString"]!).GetDatabase(configuration["MongoDb:DatabaseName"]!);
    public IMongoCollection<T> GetCollection<T>() => _mongoDatabase.GetCollection<T>(typeof(T).Name.Pluralize());
}