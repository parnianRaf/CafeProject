using CafeFlow.Framework.CommonDtos.ResultDtos;

namespace CafeFlow.Framework.Provider.Notification.Service.Contracts;

public interface INotificationService
{
    Task<FrameWorkResult> SendEmail(string emailTo, string subject, string message, CancellationToken cancellation);
}