using CafeService.FrameWorks.Dto.CafeAggDto;
using FluentValidation;

namespace CafeService.AppService.CafeAgg.Commands.AddCafeService.Validator;

public class AddCafeCommandValidator:AbstractValidator<AddCafeDto>
{
    public AddCafeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("نام کافه اجباری است.");
        RuleFor(x => x.PhoneNumber).NotEmpty()
            .WithMessage("phone numer should not be empty.");
        RuleFor(x => x.PostalCode).NotEmpty()
            .WithMessage("postal code should not be empty.")
            .Unless(x=> x.PostalCode?.Length == 10)
            .WithMessage("postal code should be 10 digits.");
        
        RuleFor(x => x.NumberPlate).NotEmpty()
            .WithMessage("number plate should not be empty.");
    }
}