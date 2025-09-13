using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppDomain.CommonEntity;

namespace CustomerService.AppDomain.CafeTableAgg;

public class CafeTable:BaseClass
{
    
    public int TableNumber { get; set; }
    
    public string CafeId { get; set; }

    public Cafe Cafe { get; set; }
}