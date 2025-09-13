using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppDomain.CafeTableAgg;
using MediatR;

namespace CustomerService.AppService.Queries.CafeAgg.ScanCafe;

public class ScanCafeHandler(ICafeService cafeService, ICacheService<Cafe> cacheService, ICustomerQueryService customerQueryService
                            ):IRequestHandler<ScanCafeQuery>
{
    public async Task Handle(ScanCafeQuery request, CancellationToken cancellationToken)
    {
        if(!cafeService.IsCafeExists(request.CafeId))
            throw CommonExceptionDto.GenerateCommonException("Tell the technical Unit" , 
                (int)HttpStatusCode.NotFound , $"there is no cafe with cafeId :{request.CafeId}");
        if(!cafeService.IsCafeTableExists(request.CafeTableId))
            throw CommonExceptionDto.GenerateCommonException("Tell the technical Unit" , 
                (int)HttpStatusCode.NotFound , $"there is no cafe table with cafeTableId :{request.CafeId}");
        var customerId =await customerQueryService.GetByUserId(cancellationToken);
        await cacheService.SetCacheAsync(typeof(Cafe), customerId, request.CafeId, cancellationToken);
        await cacheService.SetCacheAsync(typeof(CafeTable), customerId, request.CafeTableId, cancellationToken);
    }
}