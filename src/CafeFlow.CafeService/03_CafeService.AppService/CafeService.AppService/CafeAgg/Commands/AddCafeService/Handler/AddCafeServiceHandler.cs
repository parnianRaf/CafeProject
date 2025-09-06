using CafeFlow.Framework.LogAgg.Log.Contracts;
using CafeService.AppDomain.CafeAgg.Cafe;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Dto.CafeAggDto;
using CafeService.FrameWorks.Dto.OutPutDtoAgg;
using FluentValidation;
using MediatR;

namespace CafeService.AppService.CafeAgg.Commands.AddCafeService.Handler;

public class AddCafeServiceHandler(ISqlBaseGenericRepository<Cafe> cafeCommandRepository,
    IValidator<AddCafeDto> addCafeValidator
    ,IUnitOfWorks unitOfWorks
    , ILogService logService) 
    :IRequestHandler<Service.AddCafeService, OutPutDto>
{
    public async Task<OutPutDto> Handle(Service.AddCafeService request, CancellationToken cancellationToken)
    {
        await addCafeValidator.ValidateAndThrowAsync(request.CafeDto , cancellationToken);
        var cafe = Cafe.Create(request.CafeDto.Name!); 
        cafeCommandRepository.Create(cafe);
        await unitOfWorks.SaveChangesAsync();
        logService.LogInformation($"Cafe {cafe.Name} has been added");
        return new OutPutDto(true, "Successfully added cafe to service.");
    }
}