using CafeFlow.NotifcationService.Domain.Entity.Common;

namespace CafeFlow.NotifcationService.Domain.Entity;

public class EmailDetail:BaseEntity
{
    
    public string? EmailTo { get; set; }
    public string? EmailBody { get; set; }
    public string? EmailSubject { get; set; }

    public static EmailDetail GenerateEmailDetail(string emailTo, string emailBody, string emailSubject)
    {
        return new()
        {
            EmailTo = emailTo,
            EmailBody = emailBody,
            EmailSubject = emailSubject
        };
    }
}