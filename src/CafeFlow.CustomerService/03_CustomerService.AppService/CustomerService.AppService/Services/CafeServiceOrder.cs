using System.Net.Http.Json;
using CafeFlow.Framework.CommonDtos.ResultDtos;
using Contracts.Dtos.RequestDtos;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.OrderAgg.Entity;
using Newtonsoft.Json;

namespace CustomerService.AppService.Services;

public class CafeServiceOrder(IHttpClientFactory httpClientFactory) : ICafeServiceOrder
{
    
    public async Task<OutputApiResult?> PostOrder(Order order)
    {
        using var httpClient = httpClientFactory.CreateClient();
        var uri = new Uri("api/v1/Order/TakeOrder") ;
        
        
        var orderDto = OrderDto.Create(order.CafeId, order.CustomerId, order.CafeTableId);
        orderDto.OrderProductDtos.AddRange(order.OrderProducts.Select(x =>
            OrderProductDto.Create(x.ProductId, x.OrderId, x.OrderNumber, x.OrderUnitPrice)));
        
        var contentJson = JsonConvert.SerializeObject(orderDto);
        StringContent content = new StringContent(contentJson);
        var result= await httpClient.PostAsync(uri, content);
        return await result.Content.ReadFromJsonAsync<OutputApiResult>();
    }
}