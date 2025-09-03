using CafeService.AppDomain.CommonEntity;

namespace CafeService.AppDomain.CafeAgg.Entity;

public class Cafe: BaseClass
{
    private Cafe(string name)
    {
        Name = name;
    }
    public string Name { get; set; }

    public static Cafe Create(string name)
    {
        return new(name);
    }

}