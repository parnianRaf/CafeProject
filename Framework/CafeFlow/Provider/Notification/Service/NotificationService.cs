using System.Text;
using System.Text.Json;
using CafeFlow.Framework.Entity;
using CafeFlow.Framework.Provider.Notification.Service.Contracts;

namespace CafeFlow.Framework.Provider.Notification.Service;

public class NotificationService(IHttpClientFactory httpClientFactory) : INotificationService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("NotificationService");

    private async Task<OutputApiResult> PostAsync(HttpContent content , string requestUri, CancellationToken cancellationToken)
    {
        using var response = await _httpClient.PostAsync(requestUri, content , cancellationToken); 
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        return OutputApiResult.GenerateOutputApiResult((int)response.StatusCode, response.RequestMessage?.ToString() , responseBody);
    }
    
    public async Task<FrameWorkResult> SendEmail(string emailTo , string subject , string message , CancellationToken cancellation)
    {
        var content = new {Subject =subject , Body = message , EmailTo = emailTo};
        using var contentJson = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
        var response = await PostAsync(contentJson, "/api/Notification/Email", cancellation);
        return new FrameWorkResult(response.IsSuccessStatusCode , response.Message ?? "");
    }
    
}