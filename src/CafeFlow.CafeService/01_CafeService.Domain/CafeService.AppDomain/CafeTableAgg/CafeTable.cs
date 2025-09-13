using CafeService.AppDomain.CafeAgg.Entity;
using CafeService.AppDomain.CommonEntity;

namespace CafeService.AppDomain.CafeTableAgg;

public class CafeTable:BaseClass
{
    
    public int TableNumber { get; set; }
    
    public string CafeId { get; set; }

    public Cafe Cafe { get; set; }
}