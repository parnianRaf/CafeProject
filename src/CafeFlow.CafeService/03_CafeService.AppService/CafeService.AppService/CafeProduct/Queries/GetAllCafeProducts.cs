using MediatR;

namespace CafeService.AppService.CafeProduct.Queries;

public record GetAllCafeProducts(string CafeId):IRequest;