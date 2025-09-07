using CafeFlow.NotifcationService.Contracts.AppService.Contracts.Dtos.EmailDtos;

namespace CafeFlow.NotifcationService.Contracts.AppService.Contracts.Interfaces;

public interface IAddEmailDetail
{
    Task Handle(EmailServiceDto emailDetail);
}