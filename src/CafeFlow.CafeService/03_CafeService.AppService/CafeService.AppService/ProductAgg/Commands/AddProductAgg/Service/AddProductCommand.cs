using CafeFlow.Framework.ResultDtos;
using CafeService.FrameWorks.Dto.CafeAggDto;
using CafeService.FrameWorks.Dto.ProductAggDto;
using MediatR;

namespace CafeService.AppService.ProductAgg.Commands.AddProductAgg.Service;

public record AddProductCommand(AddProductDto ProductDto):IRequest<OutPutDto>;