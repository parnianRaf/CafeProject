using CafeFlow.AuthenticationService.AppService.Contracts.Dto;
using FluentValidation;

namespace CafeFlow.AuthenticationService.AppService.UserAgg.Register.Validator;

public class UserRegisterValidator:AbstractValidator<UserRegisterDto>
{

    public UserRegisterValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.");
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.");


        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Matches("^[a-zA-Z0-9]+$")
            .WithMessage("Username can only contain letters and numbers.");
        
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.");
    }
}