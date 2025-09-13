using System.Net;
using System.Security.Claims;
using CafeFlow.Framework.ExceptionAgg.Exception;
using Contracts.RepoContracts;
using Contracts.Service.Contracts;
using CustomerService.AppDomain.CustomerAgg.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.AppService.Services;

public class CustomerQueryService(IHttpContextAccessor contextAccessor, IBaseGenericRepository<Customer> customerRepository) : ICustomerQueryService
{
    public async Task<string?> GetByUserId(Guid userId, CancellationToken ct)
    {
        var customerId = await customerRepository.GetAll()
            .Where(x => x.UserId == userId)
            .Select(x => x.Id)
            .FirstOrDefaultAsync(ct);
        return customerId;

    }
    
    public async Task<string> GetByUserId( CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(!Guid.TryParse(userId, out var guidUserId))
            throw CommonExceptionDto.GenerateCommonException("tell the technical team", (int)HttpStatusCode.BadRequest, "There is no claim userId");
        var customerId =await GetByUserId(guidUserId,cancellationToken);
        if(string.IsNullOrEmpty(customerId))
            throw CommonExceptionDto.GenerateCommonException("tell the technical team", (int)HttpStatusCode.BadRequest, "There is no user by this customerId");
        return customerId!;
    }

}