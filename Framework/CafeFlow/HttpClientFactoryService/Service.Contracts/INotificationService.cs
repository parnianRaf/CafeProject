using CafeFlow.Framework.HttpClientFactoryService.Entity;

namespace CafeFlow.Framework.HttpClientFactoryService.Service.Contracts;

public interface INotificationService
{
    Task<OutputApiResult> PostAsync(HttpContent content , string requestUri, CancellationToken cancellationToken);
}