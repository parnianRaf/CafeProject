using CafeService.AppDomain.CafeAgg.ValueObjects;
using CafeService.AppDomain.CommonEntity;

namespace CafeService.AppDomain.CafeAgg.Cafe;

public class Cafe: BaseClass
{
    private Cafe(string name):base()
    {
        Name = name;
    }

    public string Name { get; set; }

    public Address Address { get; set; } = null!;
    
    public PhoneNumber PhoneNumber { get; set; } = null!;

    public static Cafe Create(string name)
    {
        return new(name);
    }

}

