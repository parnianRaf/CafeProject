using CafeFlow.Framework.LogAgg.Log.Contracts;
using CafeFlow.Framework.ResultDtos;
using CafeService.AppDomain.CafeAgg.Cafe;
using CafeService.AppService.CafeAgg.Commands.AddCafeService.Service;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Dto.CafeAggDto;
using FluentValidation;
using MediatR;

namespace CafeService.AppService.CafeAgg.Commands.AddCafeService.Handler;

public class AddCafeCommandHandler(ISqlBaseGenericRepository<Cafe> cafeCommandRepository,
    IValidator<AddCafeDto> addCafeValidator
    ,IUnitOfWorks unitOfWorks
    , ILogService logService) 
    :IRequestHandler<AddCafeCommand, OutPutDto>
{
    public async Task<OutPutDto> Handle(AddCafeCommand request, CancellationToken cancellationToken)
    {
        await addCafeValidator.ValidateAndThrowAsync(request.CafeDto , cancellationToken);
        var cafe = Cafe.Create(request.CafeDto.Name!, request.CafeDto.MainStreet,request.CafeDto.Street
            ,request.CafeDto.PostalCode,request.CafeDto.NumberPlate, request.CafeDto.PhoneNumber!); 
        cafeCommandRepository.Create(cafe);
        await unitOfWorks.SaveChangesAsync(cancellationToken);
        logService.LogInformation($"Cafe {cafe.Name} has been added");
        return new OutPutDto(true, "Successfully added cafe to service.");
    }
}