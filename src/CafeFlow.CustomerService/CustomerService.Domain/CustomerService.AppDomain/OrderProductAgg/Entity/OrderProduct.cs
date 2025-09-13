using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppDomain.CommonEntity;
using CustomerService.AppDomain.OrderAgg.Entity;
using CustomerService.AppDomain.ProductAgg.Product;

namespace CustomerService.AppDomain.OrderProductAgg.Entity;

public class OrderProduct:BaseClass
{
    private OrderProduct( string productId,string orderId, decimal price, long quantity)
    {

        ProductId = productId;
        OrderId = orderId;
        OrderNumber = quantity;
        OrderUnitPrice = price;
        OrderTotalPrice = price * quantity;
    }
    public string ProductId { get; set; }
    public virtual Product Product { get; set; }

    public string OrderId { get; set; }
    public virtual Order Order { get; set; }
    


    public long OrderNumber { get; set; }

    public decimal OrderUnitPrice { get;  set; }

    public decimal OrderTotalPrice { get; private set; }

    public static OrderProduct Create(string productId,string orderId, decimal price, long quantity)
    {
        return new(productId, orderId, price,  quantity);
    }
    

    
}