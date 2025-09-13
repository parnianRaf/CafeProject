using CafeFlow.Framework.CommonDtos.RedisDtos;

namespace CafeFlow.Framework.Caching.Service.Contracts;

public interface IRedisCachingService
{
    Task AddToObjectAsync(string customerId, Type type, string subTypeId, int quantity ,double expireHours = 24 );
    Task RemoveFromObjectAsync(string customerId, Type type, string subTypeId);
    Task DecrementObjectAsync(string customerId, Type type, string subTypeId, int quantity);
    Task ClearObjectAsync(string customerId, Type type);
    Task<RedisResultDto> GetObjectAsync(string customerId, Type type, string subTypeId);
    Task<List<RedisResultDto>> GetObjectListAsync(string customerId, Type type);

}