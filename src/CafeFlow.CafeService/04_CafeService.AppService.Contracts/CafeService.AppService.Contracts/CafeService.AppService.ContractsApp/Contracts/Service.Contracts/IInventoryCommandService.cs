using CafeService.AppDomain.CafeProductAgg.Entity;
using CafeService.FrameWorks.Dto.RequestDtos;

namespace CafeService.FrameWorks.Contracts.Service.Contracts;

public interface IInventoryCommandService
{
    void UpdateInventory(List<CafeProduct> inventory,List<OrderProductDto> orderProductDtos);
}