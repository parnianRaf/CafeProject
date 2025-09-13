using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.CommonDtos.RedisDtos;
using CafeFlow.Framework.ExceptionAgg.Exception;
using StackExchange.Redis;

namespace CafeFlow.Framework.Caching.Service;

public class RedisCachingService(IConnectionMultiplexer connectionMultiplexer) : IRedisCachingService
{
   private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
    private string GetObjectKey(Type type, string customerId) => $"{type.Name}:{customerId}";
    public async Task AddToObjectAsync(string customerId, Type type, string subTypeId, int quantity ,double expireHours = 24 )
    {
        var key = GetObjectKey(type,customerId); 
        await _database.HashIncrementAsync(key, subTypeId, quantity);
        await _database.KeyExpireAsync(key, TimeSpan.FromHours(expireHours));
    }

    public async Task RemoveFromObjectAsync(string customerId, Type type, string subTypeId)
    {
        var key = GetObjectKey(type,customerId);
        await _database.HashDeleteAsync(key ,subTypeId);
    }

    public async Task DecrementObjectAsync(string customerId, Type type, string subTypeId, int quantity)
    {
        var key = GetObjectKey(type,customerId);
        var newValue = await _database.HashDecrementAsync(key, subTypeId, quantity);
        if (newValue <= 0)
        {
            await _database.HashDeleteAsync(key ,subTypeId);
        }
    }

    public async Task ClearObjectAsync(string customerId, Type type)
    {
        var key = GetObjectKey(type,customerId);
        await _database.KeyDeleteAsync(key);
    }

    public async Task<RedisResultDto> GetObjectAsync(string customerId, Type type, string subTypeId)
    {
        var key = GetObjectKey(type,customerId);
        var value = await _database.HashGetAsync(key, subTypeId.ToString());
        if (!value.IsInteger)
            throw CommonExceptionDto.GenerateCommonException("Call The Technical Unit",
                (int)HttpStatusCode.InternalServerError, $"The Quantity of {subTypeId} in {type.Name}:{customerId} is not Integer ");
        return new RedisResultDto(customerId, type, subTypeId, (int)value);
    }
    
    public async Task<List<RedisResultDto>> GetObjectListAsync(string customerId, Type type)
    { 
        List<RedisResultDto> results = new List<RedisResultDto>();
        var key = GetObjectKey(type,customerId);
        var values = await _database.HashGetAllAsync(key);
        values.ToList().ForEach(value =>
        {
            if ( !value.Value.IsInteger ||string.IsNullOrEmpty(value.Name))
                throw CommonExceptionDto.GenerateCommonException("Call The Technical Unit",
                    (int)HttpStatusCode.InternalServerError,
                    $"The Quantity of {value.Name} in {type.Name}:{customerId} is not Integer ");
            results.Add(new(customerId,type,value.Name!,(int)value.Value));
        });
        return results;
    }

    
    

}