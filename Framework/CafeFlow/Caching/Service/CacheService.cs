using System.Text;
using CafeFlow.Framework.Caching.Service.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CafeFlow.Framework.Caching.Service;

public class CacheService<T>(IDistributedCache cache) : ICacheService<T> where T : class
{
    private string GetObjectKey(Type type, string customerId) => $"{type.Name}:{customerId}";
    public bool TryGetCache(string key,out IEnumerable<T>? resultList)
    {
        var result = cache.GetString(key);
        if (result != null)
        {
            resultList = JsonConvert.DeserializeObject<IEnumerable<T>>(result)!;
            return true;
        }
        resultList = null;
        return false;
    }
    public bool TryGetCache(Type type, string customerId,out IEnumerable<T>? resultList)
    {
        var key = GetObjectKey(type, customerId);
        var result = cache.GetString(key);
        if (result != null)
        {
            resultList = JsonConvert.DeserializeObject<IEnumerable<T>>(result)!;
            return true;
        }
        resultList = null;
        return false;
    }
    
    public bool TryGetCache(Type type, string customerId,out T? result)
    {
        var key = GetObjectKey(type, customerId);
        var resultValue = cache.GetString(key);
        if (resultValue != null)
        {
            result = JsonConvert.DeserializeObject<T>(resultValue)!;
            return true;
        }
        result = null;
        return false;
    }

    public async Task SetCacheAsync(string key, IEnumerable<T> value, CancellationToken cancelToken = default)
    {
        var valueBytes =Encoding.UTF8.GetBytes( JsonConvert.SerializeObject(value));
        await cache.SetAsync(key, valueBytes, cancelToken);
    }
    
    public async Task SetCacheAsync(Type type, string customerId, IEnumerable<T> value, CancellationToken cancelToken = default)
    {
        var key = GetObjectKey(type, customerId);
        var valueBytes =Encoding.UTF8.GetBytes( JsonConvert.SerializeObject(value));
        await cache.SetAsync(key, valueBytes, cancelToken);
    }
    public async Task SetCacheAsync(Type type, string customerId, string value, CancellationToken cancelToken = default)
    {
        var key = GetObjectKey(type, customerId);
        var valueBytes =Encoding.UTF8.GetBytes( value);
        await cache.SetAsync(key, valueBytes, cancelToken);
    } 
    public async Task SetCacheAsync(string key, IEnumerable<T> value, DistributedCacheEntryOptions cacheEntryOptions,  CancellationToken cancleToken = default)
    {
        var valueBytes =Encoding.UTF8.GetBytes( JsonConvert.SerializeObject(value));
        await cache.SetAsync(key, valueBytes,cacheEntryOptions, cancleToken);
    }
    
    public async Task SetCacheAsync(Type type, string customerId, IEnumerable<T> value, DistributedCacheEntryOptions cacheEntryOptions,  CancellationToken cancleToken = default)
    {
        var key = GetObjectKey(type, customerId);
        var valueBytes =Encoding.UTF8.GetBytes( JsonConvert.SerializeObject(value));
        await cache.SetAsync(key, valueBytes,cacheEntryOptions, cancleToken);
    }
    

}