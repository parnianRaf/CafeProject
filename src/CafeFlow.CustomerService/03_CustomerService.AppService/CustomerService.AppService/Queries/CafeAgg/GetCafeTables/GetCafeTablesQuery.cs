using CustomerService.AppDomain.CafeTableAgg;
using MediatR;

namespace CustomerService.AppService.Queries.CafeAgg.GetCafeTables;

public record GetCafeTablesQuery(string CafeId) : IRequest<IReadOnlyCollection<CafeTable>>;
