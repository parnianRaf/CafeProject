using CafeFlow.Framework.CommonDtos.ResultDtos;
using CustomerService.AppDomain.OrderAgg.Entity;

namespace Contracts.Service.Contracts;

public interface ICafeServiceOrder
{
    Task<OutputApiResult?> PostOrder(Order order);
}