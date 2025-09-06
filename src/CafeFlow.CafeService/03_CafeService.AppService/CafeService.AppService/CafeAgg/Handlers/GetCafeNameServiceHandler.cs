using CafeService.AppDomain.CafeAgg.Cafe;
using CafeService.AppService.CafeAgg.Queries;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using MediatR;

namespace CafeService.AppService.CafeAgg.Handlers;

public class GetCafeNameServiceHandler (IBaseGenericRepository<Cafe> cafeRepository):IRequestHandler<GetCafeNameService,  IReadOnlyCollection<string>>
{
    public async  Task<IReadOnlyCollection<string>> Handle(GetCafeNameService request, CancellationToken cancellationToken)
    {
        var cafeNames = cafeRepository
            .GetAll()
            .Select(x => x.Name)
            .ToList();

        return await Task.FromResult<IReadOnlyCollection<string>>(cafeNames);
    }
}