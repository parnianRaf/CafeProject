using CafeFlow.NotifcationService.AppService.EmailAgg;
using CafeFlow.NotifcationService.Contracts.AppService.Contracts.Dtos.EmailDtos;
using CafeFlow.NotifcationService.Contracts.AppService.Contracts.Interfaces;
using CafeFlow.NotifcationService.DataAccess.Repo;
using CafeFlow.NotifcationService.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.NotifcationService.Controller;
[ApiController]
[Route("api/[controller]")]
public class NotificationController(IEmailService emailService) :ControllerBase
{
    [HttpPost(nameof(Email))]
    public async Task<IActionResult> Email(EmailServiceDto emailDto )
    {
        await emailService.SendEmailMAilKit(emailDto);
        return Ok();
    }
    [HttpPost(nameof(EmailList))]
    public async Task<IActionResult> EmailList(EmailListServiceDto emailDtos )
    {
        await emailService.SendEmailMAilKit(emailDtos);
        return Ok();
    }

}