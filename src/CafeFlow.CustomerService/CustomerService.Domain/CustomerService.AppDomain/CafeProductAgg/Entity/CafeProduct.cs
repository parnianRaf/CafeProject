using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppDomain.CommonEntity;
using CustomerService.AppDomain.ProductAgg.Product;

namespace CustomerService.AppDomain.CafeProductAgg.Entity;

public class CafeProduct:BaseClass
{
    public long Inventory { get; set; }
    public decimal Price { get; set; }
    public string CafeId { get; set; } 
    public string ProductId { get; set; }
    public virtual Cafe Cafe { get; set; }
    public virtual Product Product { get; set; }

}