using CustomerService.AppDomain.CommonEntity;
using CustomerService.AppDomain.CustomerAgg.Enum;

namespace CustomerService.AppDomain.CustomerAgg.Entity;

public class Customer:BaseClass
{
    private Customer(Guid userId,Gender gender, int? age)
    {
        Gender = gender;
        Age = age;
        UserId = userId;
    }
    public Guid UserId { get; private set; }

    public Gender Gender { get; private set; }

    public int? Age { get; private set; }

    public static Customer Create(Guid userId, Gender gender, int? age)
    {
        return new(userId, gender, age);
    }
}