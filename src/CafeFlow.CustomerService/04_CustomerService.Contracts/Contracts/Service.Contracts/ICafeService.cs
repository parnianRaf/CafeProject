using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppDomain.CafeTableAgg;

namespace Contracts.Service.Contracts;

public interface ICafeService
{
    IReadOnlyCollection<Cafe> GetCafes();
    bool IsCafeExists(string cafeId);
    string GetCafeFromCache(string customerId);
    IReadOnlyCollection<CafeTable> GetCafeTables(string cafeId);
    bool IsCafeTableExists(string cafeTableId);
    string GetCafeTableFromCache(string customerId);
}