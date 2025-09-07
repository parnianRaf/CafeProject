using CafeService.AppService.CafeProduct.Queries;
using MediatR;

namespace CafeService.AppService.CafeProduct.Handler.Queries;

public class GetAllProductsHandler:IRequestHandler<GetAllCafeProducts>
{
    public Task Handle(GetAllCafeProducts request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}