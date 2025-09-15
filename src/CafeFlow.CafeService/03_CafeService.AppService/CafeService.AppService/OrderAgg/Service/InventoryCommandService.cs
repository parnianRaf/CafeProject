using CafeService.AppDomain.CafeProductAgg.Entity;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Contracts.Service.Contracts;
using CafeService.FrameWorks.Dto.RequestDtos;

namespace CafeService.AppService.OrderAgg.Service;

public class InventoryCommandService : IInventoryCommandService
{
    public void UpdateInventory(List<CafeProduct> inventory,List<OrderProductDto> orderProductDtos)
    {
        var orderProductDict = orderProductDtos.ToDictionary(x => x.ProductId);
        foreach (var obj in inventory)
        {
            if (orderProductDict.TryGetValue(nameof(OrderProductDto.ProductId), out var orderProductDto)
                && orderProductDto.ProductId == obj.ProductId)
            {
                obj.Inventory -= orderProductDto.OrderNumber;
            }
        }
    }
}