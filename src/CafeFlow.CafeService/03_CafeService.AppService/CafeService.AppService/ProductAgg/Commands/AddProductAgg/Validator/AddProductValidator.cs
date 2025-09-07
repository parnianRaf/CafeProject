using CafeService.FrameWorks.Dto.ProductAggDto;
using FluentValidation;

namespace CafeService.AppService.ProductAgg.Commands.AddProductAgg.Validator;

public class AddProductValidator:AbstractValidator<AddProductDto>
{
    public AddProductValidator()
    {
        RuleFor(x => x.Name).NotNull()
            .NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description)
            .MaximumLength(350).WithMessage("Description length exceeded");
        RuleFor(x => x.ProductCode)
            .MaximumLength(100).WithMessage("Product code length exceeded");
    }
}