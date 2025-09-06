namespace CafeService.AppDomain.CommonEntity;

public abstract class BaseClass
{
    public BaseClass()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }

    public bool IsDeleted { get; set; }
}