namespace CafeFlow.NotifcationService.Domain.Entity.Common;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
}