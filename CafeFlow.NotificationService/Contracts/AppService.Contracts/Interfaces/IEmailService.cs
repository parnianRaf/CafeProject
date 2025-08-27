using CafeFlow.NotifcationService.AppService.Contracts.Dtos;

namespace CafeFlow.NotifcationService.AppService.Contracts.Interfaces;

public interface IEmailService
{
    Task SendEmailMAilKit(EmailServiceDto emailServiceDto);
    Task SendEmailMAilKit(EmailListServiceDto emailServiceDtos);

}