using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using FluentValidation;

namespace CafeFlow.AuthenticationService.AppService.UserAgg.LogIn.Validator;

public class UserLogInValidator: AbstractValidator<UserLogInDto>
{
    public UserLogInValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}