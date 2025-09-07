using CafeFlow.NotifcationService.Contracts.AppService.Contracts.Dtos.EmailDtos;
using CafeFlow.NotifcationService.Contracts.AppService.Contracts.Interfaces;
using CafeFlow.NotifcationService.Contracts.Repo.Contracts;
using CafeFlow.NotifcationService.DataAccess.Context;
using CafeFlow.NotifcationService.DataAccess.Repo;
using CafeFlow.NotifcationService.Domain.Entity;
using MongoDB.Driver;

namespace CafeFlow.NotifcationService.AppService.EmialDetailAgg.Service;

public class AddEmailDetail(IEntityDetailRepo<EmailDetail> emailDateilRepo) : IAddEmailDetail
{

    public async Task Handle(EmailServiceDto emailDetail)
    {
        var email = EmailDetail.GenerateEmailDetail(emailDetail.EmailTo!, emailDetail.Body!, emailDetail.Subject!);
        await emailDateilRepo.Create(email);
    }
}