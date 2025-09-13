using CafeService.AppDomain.CafeProductAgg.Entity;
using CafeService.FrameWorks.Dto.RequestDtos;

namespace CafeService.AppService.OrderAgg.Service;

public interface IInventoryCommandService
{
    void UpdateInventory(List<CafeProduct> inventory,List<OrderProductDto> orderProductDtos);
}