using CafeFlow.Framework.CommonDtos.ResultDtos;
using CafeService.FrameWorks.Dto.CafeAggDto;
using MediatR;

namespace CafeService.AppService.CafeAgg.Commands.AddCafeService.Service;

public record AddCafeCommand(AddCafeDto CafeDto) : IRequest<OutPutDto>;
