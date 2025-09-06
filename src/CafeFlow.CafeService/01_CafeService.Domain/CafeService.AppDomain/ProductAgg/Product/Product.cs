using CafeService.AppDomain.CommonEntity;

namespace CafeService.AppDomain.ProductAgg.Product;

public class Product:BaseClass
{
    public string Name { get; set; } = null!;
    public string? ProductCode { get; set; }
    public string? Description { get; set; }
}