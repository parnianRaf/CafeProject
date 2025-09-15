using System.Text;
using CafeFlow.Framework.CommonDtos.ResultDtos.ServiceDto;
using CafeService.AppDomain.CafeProductAgg.Entity;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Contracts.Service.Contracts;
using CafeService.FrameWorks.Dto.RequestDtos;
using Microsoft.EntityFrameworkCore;

namespace CafeService.AppService.OrderAgg.Service;

public class InventoryQueryService(IBaseGenericRepository<CafeProduct> cafeProductRepository) : IInventoryQueryService
{

    public async Task<CommonServiceDto<StringBuilder>> HasInventory(OrderDto orderDto)
    {
        StringBuilder resultMessage = new StringBuilder();
        bool hasInventory = true;
        var cafeProducts =
            await cafeProductRepository.GetAll().Where(x => x.CafeId == orderDto.CafeId 
                                                      && orderDto.OrderProductDtos.Any(op => op.ProductId == x.ProductId))
                                                .ToListAsync();
        var cafeProductDict = cafeProducts.ToDictionary(p => p.ProductId);

        foreach (var orderProduct in orderDto.OrderProductDtos)
        { 
            if (!cafeProductDict.TryGetValue(orderProduct.ProductId, out var cafeProduct))
            {
                resultMessage.AppendLine($"Product {orderProduct.ProductId} does not exist in the cafe.");
                hasInventory = false;
            }
            else  if (cafeProduct!.Inventory < orderProduct.OrderNumber)
            {
                resultMessage.Append($"the product {orderProduct.ProductId} is out of stock.");
                hasInventory = false;
            }
        }
        return hasInventory ?
            CommonServiceDto<StringBuilder>.CreateSuccess(resultMessage)
            : CommonServiceDto<StringBuilder>.CreateFailed(resultMessage);
    }

    public async Task<List<CafeProduct>> GetAllCafeProducts(OrderDto orderDto)
    {
        return await cafeProductRepository.GetAll().Where(x => x.CafeId == orderDto.CafeId
                                && orderDto.OrderProductDtos.Select(x => x.ProductId)
                                    .Contains(x.ProductId)).ToListAsync();
    }
    
}