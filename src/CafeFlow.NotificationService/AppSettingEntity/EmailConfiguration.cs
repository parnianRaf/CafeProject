namespace CafeFlow.NotifcationService.AppSettingEntity;

public class EmailConfiguration
{
    public string Name { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public EmailProvider EmailProvider { get; set; } =  null!;
}