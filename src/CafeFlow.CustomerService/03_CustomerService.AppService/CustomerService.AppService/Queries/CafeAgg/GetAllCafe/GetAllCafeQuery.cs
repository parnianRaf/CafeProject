using CustomerService.AppDomain.CafeAgg.Entity;
using MediatR;

namespace CustomerService.AppService.Queries.CafeAgg.GetAllCafe;

public record GetAllCafeQuery():IRequest<IReadOnlyCollection<Cafe>>;