using CafeFlow.NotifcationService.Contracts.AppService.Contracts.Dtos.EmailDtos;

namespace CafeFlow.NotifcationService.Contracts.AppService.Contracts.Interfaces;

public interface IEmailService
{
    Task SendEmailMAilKit(EmailServiceDto emailServiceDto);
    Task SendEmailMAilKit(EmailListServiceDto emailServiceDtos);

}