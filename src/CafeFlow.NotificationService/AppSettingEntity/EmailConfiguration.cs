namespace CafeFlow.NotifcationService.AppSettingEntity;

public class EmailConfiguration
{
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public EmailProvider EmailProvider { get; set; }
}