using CafeService.FrameWorks.Dto.CafeAggDto;
using CafeService.FrameWorks.Dto.OutPutDtoAgg;
using MediatR;

namespace CafeService.AppService.CafeAgg.Commands.AddCafeService.Service;

public record AddCafeService(AddCafeDto CafeDto) : IRequest<OutPutDto>;
