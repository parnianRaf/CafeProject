using Contracts.Service.Contracts;
using CustomerService.AppDomain.CafeTableAgg;
using MediatR;

namespace CustomerService.AppService.Queries.CafeAgg.GetCafeTables;

public class GetCafeTablesQueryHandler(ICafeService cafeService):IRequestHandler<GetCafeTablesQuery,IReadOnlyCollection<CafeTable>>
{
    public async Task<IReadOnlyCollection<CafeTable>> Handle(GetCafeTablesQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(cafeService.GetCafeTables(request.CafeId));
    }
}