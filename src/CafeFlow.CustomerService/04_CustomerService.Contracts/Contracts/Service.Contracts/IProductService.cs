namespace Contracts.Service.Contracts;

public interface IProductService
{
    void GetProductByCafeId(string cafeId, string? productId, int? quantity, bool checkInventory = true);
}