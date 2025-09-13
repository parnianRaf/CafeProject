using CafeService.AppDomain.CafeAgg.Entity;
using CafeService.AppDomain.CafeTableAgg;
using CafeService.AppDomain.CommonEntity;
using CafeService.AppDomain.CustomerAgg.Entity;
using CafeService.AppDomain.OrderProductAgg.Entity;

namespace CafeService.AppDomain.OrderAgg.Entity;

public class Order : BaseClass    
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