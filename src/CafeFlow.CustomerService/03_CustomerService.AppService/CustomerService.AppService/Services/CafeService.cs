using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.RepoContracts;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppDomain.CafeTableAgg;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.AppService.Services;

public class CafeService(ICacheService<CafeTable> cafeTableCaching,ICacheService<Cafe> cafeCaching) : ICafeService
{
    public IReadOnlyCollection<Cafe> GetCafes()
    {
        if(!cafeCaching.TryGetCache(nameof(Cafe), out var cafes))
            throw CommonExceptionDto.GenerateCommonException("there is no cafe", (int)HttpStatusCode.NotFound
            ,"tehre is no cafe in cache");
        return cafes!.ToList();
    }

    public IReadOnlyCollection<CafeTable> GetCafeTables(string cafeId)
    {
        if(!cafeTableCaching.TryGetCache(cafeId, out var cafeTables))
            throw CommonExceptionDto.GenerateCommonException("There is no table cafes",  (int)HttpStatusCode.NotFound,
                "there is no cafe in cache");
        return cafeTables!.Where(x => x.CafeId == cafeId).ToList();
    }

    public bool IsCafeExists(string cafeId)
    {
        cafeCaching.TryGetCache(nameof(Cafe), out var cafes);
        return cafes?.Single(x => x.Id == cafeId) != null;
    }
    public bool IsCafeTableExists(string cafeTableId)
    {
        cafeTableCaching.TryGetCache(nameof(Cafe), out var cafes);
        return cafes?.Single(x => x.Id == cafeTableId) != null;
    }

    public string GetCafeFromCache(string customerId)
    {
        if(!cafeCaching.TryGetCache(typeof(Cafe), customerId, out Cafe? cafe)|| cafe is null)
            throw CommonExceptionDto.GenerateCommonException("Scan One More Time", (int)HttpStatusCode.BadRequest
                             ,$"There was no cafeId in cache for customer : {customerId}");
        return cafe.Id;
    }
    
    public string GetCafeTableFromCache(string customerId)
    {
        if(!cafeTableCaching.TryGetCache(typeof(Cafe), customerId, out CafeTable? cafeTable)|| cafeTable is null)
            throw CommonExceptionDto.GenerateCommonException("Scan One More Time", (int)HttpStatusCode.BadRequest
                ,$"There was no cafeTableId in cache for customer :{customerId}");
        return cafeTable.Id;
    }
    


}