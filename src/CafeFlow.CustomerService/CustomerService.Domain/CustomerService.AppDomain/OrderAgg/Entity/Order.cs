using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppDomain.CafeTableAgg;
using CustomerService.AppDomain.CommonEntity;
using CustomerService.AppDomain.CustomerAgg.Entity;
using CustomerService.AppDomain.OrderProductAgg.Entity;

namespace CustomerService.AppDomain.OrderAgg.Entity;

public class Order:BaseClass
{
    private Order(string cafeId,string cafeTableId, string customerId)
    {
        
    }
    // #region Price Section
    // public decimal TotalTax { get; set; }
    // public decimal TotalToll { get; set; }
    // public decimal CustomerPrice { get; set; }
    // public decimal CustomerPriceWithoutTax { get; set; }
    // #endregion

    //Cafe
    public string CafeId { get; set; }
    public virtual Cafe Cafe { get; set; }
    //
    
    //Cafe Table
    public string CafeTableId { get; set; }
    public virtual CafeTable CafeTable { get; set; }
    //
    
    //Customer
    public string CustomerId { get; set; }    
    public virtual Customer Customer { get; set; }
    //
    
    
    //ProductList
    public virtual List<OrderProduct>  OrderProducts { get; set; }
    //productList


    public static Order Create(string cafeId, string cafeTableId, string customerId)
    {
        return new(cafeId ,cafeTableId ,customerId);
    }

 
    

    
    
}