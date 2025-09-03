using CafeService.FrameWorks.Dto.CafeAggDto;
using FluentValidation;

namespace CafeService.AppService.CafeAgg.Commands.AddCafeService.Validator;

public class AddCafeServiceValidator:AbstractValidator<AddCafeDto>
{
    public AddCafeServiceValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("نام کافه اجباری است.");
    }
}