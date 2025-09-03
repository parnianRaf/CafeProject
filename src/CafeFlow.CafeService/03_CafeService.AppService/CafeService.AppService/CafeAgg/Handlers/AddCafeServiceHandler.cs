using CafeFlow.Framework.LogAgg.Log.Contracts;
using CafeService.AppDomain.CafeAgg.Entity;
using CafeService.AppService.CafeAgg.Commands;
using CafeService.AppService.CafeAgg.Commands.AddCafeService.Service;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Dto.CafeAggDto;
using CafeService.FrameWorks.Dto.OutPutDtoAgg;
using FluentValidation;
using MediatR;

namespace CafeService.AppService.CafeAgg.Handlers;

public class AddCafeServiceHandler(ICommandBaseGenericRepository<Cafe> cafeCommandRepository,IValidator<AddCafeDto> addCafeValidator
    , ILogService logService) 
    :IRequestHandler<AddCafeService, OutPutDto>
{
    public async Task<OutPutDto> Handle(AddCafeService request, CancellationToken cancellationToken)
    {
        await addCafeValidator.ValidateAndThrowAsync(request.CafeDto , cancellationToken);
        var cafe = Cafe.Create(request.CafeDto.Name);
        await cafeCommandRepository.Create(cafe);
        logService.LogInformation($"Cafe {cafe.Name} has been added");
        return new OutPutDto(true, "Successfully added cafe to service.");
    }
}