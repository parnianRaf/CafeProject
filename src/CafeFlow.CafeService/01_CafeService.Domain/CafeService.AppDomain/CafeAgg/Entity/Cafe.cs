using CafeService.AppDomain.CafeAgg.ValueObjects;
using CafeService.AppDomain.CafeProductAgg.Entity;
using CafeService.AppDomain.CommonEntity;

namespace CafeService.AppDomain.CafeAgg.Entity;

public class Cafe: BaseClass
{
    private Cafe()
    {
    }

    private Cafe(string name , string? mainStreet, string? street ,
        string? postalCode, int? numberPlate , string phoneNumber ):base()
    {
        Name = name;
        Address = new Address(mainStreet, street, postalCode, numberPlate);
        PhoneNumber = new PhoneNumber(phoneNumber);
    }

    public string Name { get; set; }

    public Address Address { get; set; } 
    
    public PhoneNumber PhoneNumber { get; set; } 
    
    public virtual  List<CafeProduct> CafeProducts { get; set; }

    public static Cafe Create(string name, string? mainStreet, string? street ,string? postalCode, int? numberPlate , string phoneNumber)
    {
        return new(name, mainStreet, street, postalCode, numberPlate, phoneNumber);
    }

}

