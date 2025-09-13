using CafeFlow.Framework.CommonDtos.ResultDtos;
using CafeFlow.Framework.LogAgg.Log.Contracts;
using CafeService.AppDomain.ProductAgg.Product;
using CafeService.AppService.ProductAgg.Commands.AddProductAgg.Service;
using CafeService.FrameWorks.Contracts.Repository.Contracts;
using CafeService.FrameWorks.Dto.ProductAggDto;
using FluentValidation;
using MediatR;

namespace CafeService.AppService.ProductAgg.Commands.AddProductAgg.Handler;

public class AddProductCommandHandler(IValidator<AddProductDto> validator, ISqlBaseGenericRepository<Product> productRepository
     , IUnitOfWorks unitOfWorks , ILogService logService)
    :IRequestHandler<AddProductCommand , OutPutDto>
{
    public async Task<OutPutDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request.ProductDto,cancellationToken);
        var productEntity = Product.Create(request.ProductDto.Name! , request.ProductDto.ProductCode,  request.ProductDto.Description);
        productRepository.Create(productEntity);
        await unitOfWorks.SaveChangesAsync(cancellationToken);
        logService.LogInformation("Successfully added product");
        return new OutPutDto(true,"Successfully added product");
    }
}