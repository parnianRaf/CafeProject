using Contracts.Dtos;
using Contracts.RepoContracts;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.CustomerAgg.Entity;
using Newtonsoft.Json;

namespace CustomerService.AppService.Services;

public class CustomerCommandService(IHttpClientFactory clientFactory, 
    ISqlBaseGenericRepository<Customer> customerRepository
    ,IUnitOfWorks unitOfWorks) : ICustomerService
{
    
    public async Task<Guid?> AddUserIfNotExist(AddCustomerDto  addCustomerDto , CancellationToken ct)
    {
        using var userClient = clientFactory.CreateClient();
        var content = JsonConvert.SerializeObject(addCustomerDto);
        var response = await userClient.PostAsync("api/User/RegisterCustomerUserIfNotExists", new StringContent(content), ct);
        var resultMessage = await response.Content.ReadAsStringAsync(ct);
        return Guid.TryParse(resultMessage, out var resultGuid) ? resultGuid : null;
    }

    public async Task AddCustomer(AddCustomerDto addCustomerDto, Guid userId, CancellationToken ct)
    {
        var customer = Customer.Create(userId, addCustomerDto.Gender, addCustomerDto.Age);
        customerRepository.Create(customer);
        await unitOfWorks.SaveChangesAsync(ct);
    }

 
}