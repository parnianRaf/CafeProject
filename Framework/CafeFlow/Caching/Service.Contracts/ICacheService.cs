using Microsoft.Extensions.Caching.Distributed;

namespace CafeFlow.Framework.Caching.Service.Contracts;

public interface ICacheService<T> where T : class
{
    bool TryGetCache(string key,out IEnumerable<T>? resultList);
     bool TryGetCache(Type type, string customerId, out IEnumerable<T>? resultList);
    Task SetCacheAsync(string key, IEnumerable<T> value, CancellationToken cancelToken = default);
    bool TryGetCache(Type type, string customerId, out T? result);

    Task SetCacheAsync(Type type, string customerId, IEnumerable<T> value,
        CancellationToken cancelToken = default);

    Task SetCacheAsync(Type type, string customerId, string value,
        CancellationToken cancelToken = default);
    Task SetCacheAsync(string key, IEnumerable<T> value, DistributedCacheEntryOptions cacheEntryOptions,  CancellationToken cancleToken = default);

    Task SetCacheAsync(Type type, string customerId, IEnumerable<T> value,
        DistributedCacheEntryOptions cacheEntryOptions, CancellationToken cancleToken = default);

}