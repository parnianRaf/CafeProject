using CafeFlow.NotifcationService.AppService.Contracts.Dtos;
using FluentValidation;

namespace CafeFlow.NotifcationService.AppService.EmailAgg.Validate;

public class EmailListServiceDtoValidate :AbstractValidator<EmailListServiceDto>
{
    public EmailListServiceDtoValidate()
    {
        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject is required")
            .MaximumLength(100).WithMessage("Subject must not exceed 100 characters");
        
        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("Body is required");
        
        RuleFor(x => x.EmailTos)
            .ForEach(x => 
                x.EmailAddress().WithMessage("Enter valid email address"));
            




    }
}