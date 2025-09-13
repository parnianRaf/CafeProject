using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.CommonDtos.RedisDtos;
using CafeFlow.Framework.CommonDtos.ResultDtos.ServiceDto;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.RepoContracts;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.CafeProductAgg.Entity;
using CustomerService.AppDomain.OrderAgg.Entity;
using CustomerService.AppDomain.OrderProductAgg.Entity;
using CustomerService.AppService.Commands.OrderAgg.SubmitOrder;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CustomerService.AppService.Services;

public class OrderService(IRedisCachingService redisCaching, ICacheService<CafeProduct> cafeProductCache
        ,ISqlBaseGenericRepository<Order> orderRepository
        ,ISqlBaseGenericRepository<OrderProduct> orderProductRepository) : IOrderService
{

 
    public async Task<Order> AddOrder(string customerId, string cafeId, string cafeTableId)
    {
        var cafeProductResults = GetCafeProductInCache();
        if(!cafeProductResults.IsSuccess)
            throw CommonExceptionDto.GenerateCommonException("Tell the Technical Unit ", 
                (int)HttpStatusCode.NotFound,"there is no cafe product in cache");
        
        var thisCafeProducts = cafeProductResults.Result!.Where(cp => cp.Id == cafeId).ToList();
        var orderObjectList = await redisCaching.GetObjectListAsync(customerId, typeof(Order));
        
        
        if (!thisCafeProducts?.Any() ?? true)
            throw CommonExceptionDto.GenerateCommonException("this cafe has no products");
        
        if(thisCafeProducts!.All(x => orderObjectList.Any(ool => x.ProductId == ool.ProductId) ))
            throw CommonExceptionDto.GenerateCommonException("this cafe has no such products", (int)HttpStatusCode.NotFound);
      
        var orderEntity =Order.Create(cafeId, cafeTableId, customerId); 
        orderRepository.Create(orderEntity);
        var orderProducts = AddOrderProducts(orderObjectList,thisCafeProducts,orderEntity.Id);
        orderProductRepository.CreateAll(orderProducts);
        return orderEntity;
    }

    private CommonServiceDto<List<CafeProduct>>  GetCafeProductInCache()
    {
        if(cafeProductCache.TryGetCache(nameof(CafeProduct), out var cafeProducts))
            return CommonServiceDto<List<CafeProduct>>.CreateSuccess(cafeProducts!.ToList());
        return CommonServiceDto<List<CafeProduct>>.CreateFailed();
    }

    private List<OrderProduct> AddOrderProducts(List<RedisResultDto> orderProductResults,List<CafeProduct> cafeProducts, string orderId)
    {
        var orderProducts = new List<OrderProduct>();
        orderProductResults.ForEach(order =>
        {
            var cafeProduct = cafeProducts.FirstOrDefault(x => x.ProductId == order.ProductId);
            orderProducts.Add(OrderProduct.Create(cafeProduct!.ProductId,orderId,cafeProduct!.Price, cafeProduct!.Inventory));
        });
        return orderProducts;
    }


}