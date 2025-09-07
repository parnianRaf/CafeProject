using MediatR;

namespace CafeService.AppService.CafeAgg.Queries;

public record GetCafeNameService():IRequest<IReadOnlyCollection<string>>;