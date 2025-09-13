using System.Net;
using CafeFlow.Framework.Caching.Service.Contracts;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.RepoContracts;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.CafeProductAgg.Entity;
using CustomerService.AppDomain.ProductAgg.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace CustomerService.AppService.Services;

public class ProductService(ICacheService<Product> productCache, ICacheService<CafeProduct> cafeProductCache) : IProductService
{
    private bool IsThisProductIdExist(string? productId)
    {
        if (string.IsNullOrEmpty(productId))
            return false;
        productCache.TryGetCache(nameof(Product), out var products);
        
        return  products?.Single(x => x.Id == productId) != null;
    }
    
    private bool IsThisProductIdExist(string productId, string cafeId)
    {
        if (string.IsNullOrEmpty(productId))
            return false;
        cafeProductCache.TryGetCache(nameof(CafeProduct), out var cafeProducts);
        return  cafeProducts?.Single(x => x.ProductId == productId && x.CafeId == cafeId) != null;
    }

    private bool HasThisProductInventoryInThisCafe(string productId, string cafeId, int quantity)
    {
        cafeProductCache.TryGetCache(nameof(CafeProduct), out var cafeProducts);
        var cafeProduct = cafeProducts!.Single(x => x.ProductId == productId && x.CafeId == cafeId);
        return (cafeProduct.Inventory - quantity) >= 0;
    }

    public void GetProductByCafeId(string cafeId, string? productId,int? quantity,bool checkInventory = true)
    {
        if(! IsThisProductIdExist(productId))
            throw CommonExceptionDto.GenerateCommonException($"Tel the Technical Unit ",
                (int)HttpStatusCode.InternalServerError,$"There is No Product with this productId : {productId} ");
        
        if( IsThisProductIdExist(productId!,cafeId))
            throw CommonExceptionDto.GenerateCommonException($"Tel the Technical Unit ",
                (int)HttpStatusCode.InternalServerError,$"There is No Product with this productId : {productId} in this cafe (cafId : {cafeId}) ");
        
        if(checkInventory && quantity is not null &&  HasThisProductInventoryInThisCafe(productId!,cafeId,(int)quantity!))
            throw CommonExceptionDto.GenerateCommonException($"This Product is out of Inventory",
                (int)HttpStatusCode.BadRequest,$"There is No Inventory for  Product with this productId : {productId} in this cafe (cafId : {cafeId}) ");

    }


}