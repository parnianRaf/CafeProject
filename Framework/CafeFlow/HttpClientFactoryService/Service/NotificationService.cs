using CafeFlow.Framework.HttpClientFactoryService.Entity;
using CafeFlow.Framework.HttpClientFactoryService.Service.Contracts;

namespace CafeFlow.Framework.HttpClientFactoryService.Service;

public class NotificationService(IHttpClientFactory httpClientFactory) : INotificationService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("NotificationService");

    public async Task<OutputApiResult> PostAsync(HttpContent content , string requestUri, CancellationToken cancellationToken)
    {
        using var response = await _httpClient.PostAsync(requestUri, content , cancellationToken); 
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        return OutputApiResult.GenerateOutputApiResult((int)response.StatusCode, response.RequestMessage?.ToString() , responseBody);
    }
    
}