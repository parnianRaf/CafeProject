namespace CafeService.AppDomain.CommonEntity;

public abstract class BaseClass
{
    public BaseClass()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}