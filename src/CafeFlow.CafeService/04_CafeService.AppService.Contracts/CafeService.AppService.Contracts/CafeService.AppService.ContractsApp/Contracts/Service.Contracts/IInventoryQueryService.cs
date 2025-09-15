using System.Text;
using CafeFlow.Framework.CommonDtos.ResultDtos.ServiceDto;
using CafeService.AppDomain.CafeProductAgg.Entity;
using CafeService.FrameWorks.Dto.RequestDtos;

namespace CafeService.FrameWorks.Contracts.Service.Contracts;

public interface IInventoryQueryService
{
    Task<CommonServiceDto<StringBuilder>> HasInventory(OrderDto orderDto);
    Task<List<CafeProduct>> GetAllCafeProducts(OrderDto orderDto);
}