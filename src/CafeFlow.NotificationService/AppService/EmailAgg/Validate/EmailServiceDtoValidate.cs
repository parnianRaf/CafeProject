using CafeFlow.NotifcationService.Contracts.AppService.Contracts.Dtos.EmailDtos;
using FluentValidation;

namespace CafeFlow.NotifcationService.AppService.EmailAgg.Validate;

public class EmailServiceDtoValidate:AbstractValidator<EmailServiceDto>
{
    public EmailServiceDtoValidate()
    {
        RuleFor(x => x.EmailTo)
            .NotEmpty().WithMessage("Email address cannot be empty")
            .EmailAddress().WithMessage("Enter valid email address");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject cannot be empty")
            .MaximumLength(100).WithMessage("Subject cannot be longer than 100 characters");

        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("Body cannot be empty");
    }
}