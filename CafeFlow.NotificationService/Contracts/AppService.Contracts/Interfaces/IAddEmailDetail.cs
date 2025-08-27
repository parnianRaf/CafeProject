using CafeFlow.NotifcationService.AppService.Contracts.Dtos;
using CafeFlow.NotifcationService.Domain.Entity;

namespace CafeFlow.NotifcationService.AppService.EmialDetailAgg.Service;

public interface IAddEmailDetail
{
    Task Handle(EmailServiceDto emailDetail);
}