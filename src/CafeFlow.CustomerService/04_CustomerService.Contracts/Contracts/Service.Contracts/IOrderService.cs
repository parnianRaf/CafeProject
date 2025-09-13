using CustomerService.AppDomain.OrderAgg.Entity;

namespace Contracts.Service.Contracts;

public interface IOrderService
{
    Task<Order> AddOrder(string customerId, string cafeId, string cafeTableId);
}