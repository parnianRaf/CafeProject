using CustomerService.AppDomain.CafeProductAgg.Entity;
using CustomerService.AppDomain.CommonEntity;

namespace CustomerService.AppDomain.ProductAgg.Product;

public class Product:BaseClass
{
    private Product(string name, string? productCode, string? description) : base()
    {
        Name = name;
        ProductCode = productCode;
        Description = description;
    }
    public string Name { get; set; }
    public string? ProductCode { get; set; }
    public string? Description { get; set; }

    public virtual  List<CafeProduct> CafeProducts { get; set; }

    public static Product Create(string name, string? productCode, string? description)
    {
        return new(name, productCode, description);
    }
    
}