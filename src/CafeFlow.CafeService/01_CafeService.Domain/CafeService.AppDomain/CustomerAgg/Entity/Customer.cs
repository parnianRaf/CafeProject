using CafeService.AppDomain.CommonEntity;
using CafeService.AppDomain.CustomerAgg.Enum;

namespace CafeService.AppDomain.CustomerAgg.Entity;

public class Customer:BaseClass
{
    private Customer(Guid userId, Gender gender,int age)
    {
        UserId = userId;
        Gender = gender;
        Age = age;
    }
    public Guid UserId { get; private set; }

    public Gender Gender { get; private set; }

    public int? Age { get; private set; } 
}