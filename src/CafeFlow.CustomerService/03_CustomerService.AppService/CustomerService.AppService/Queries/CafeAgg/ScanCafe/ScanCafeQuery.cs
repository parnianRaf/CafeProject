using MediatR;

namespace CustomerService.AppService.Queries.CafeAgg.ScanCafe;

public record ScanCafeQuery(string CafeId, string CafeTableId):IRequest;
