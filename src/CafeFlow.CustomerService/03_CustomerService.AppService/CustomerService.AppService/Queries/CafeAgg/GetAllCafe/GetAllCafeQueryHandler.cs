using Contracts.Service.Contracts;
using CustomerService.AppDomain.CafeAgg.Entity;
using CustomerService.AppService.Services;
using MediatR;

namespace CustomerService.AppService.Queries.CafeAgg.GetAllCafe;

public class GetAllCafeQueryHandler(ICafeService cafeService):IRequestHandler<GetAllCafeQuery, IReadOnlyCollection<Cafe>>
{
    public async Task<IReadOnlyCollection<Cafe>> Handle(GetAllCafeQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(cafeService.GetCafes());
    }
}