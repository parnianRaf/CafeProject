using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using CafeFlow.Framework.Exception;
using MimeKit;
using CafeFlow.NotifcationService.AppService.Contracts.Dtos;
using CafeFlow.NotifcationService.AppService.Contracts.Interfaces;
using CafeFlow.NotifcationService.AppService.EmialDetailAgg.Service;
using CafeFlow.NotifcationService.AppSettingEntity;
using FluentValidation;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace CafeFlow.NotificationService.AppService.EmailAgg.Service;

public class EmailService(IValidator<EmailServiceDto> validator , IValidator<EmailListServiceDto> listValidator 
    ,EmailConfiguration configure, IAddEmailDetail emailDetail) : IEmailService
{

    
    public async Task SendEmailMAilKit(EmailServiceDto emailServiceDto)
    {
        string? result = string.Empty;
        try
        {
            await validator.ValidateAndThrowAsync(emailServiceDto);
    
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(configure.Name, configure.EmailAddress));
            message.To.Add(MailboxAddress.Parse(emailServiceDto.EmailTo!));
            message.Subject = emailServiceDto.Subject!;
            message.Body =  new TextPart("html") { Text = emailServiceDto.Body! };
    
            using var client = new SmtpClient();
            await client.ConnectAsync(configure.EmailProvider.HostEmailProvider, configure.EmailProvider.PortEmailProvider, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(configure.EmailAddress, configure.Password);
            result = await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            throw new CommonExceptionDto(e);
        }

        if (!string.IsNullOrEmpty(result))
        {
            await emailDetail.Handle(emailServiceDto);
        }

      
    }


    public async Task SendEmailMAilKit(EmailListServiceDto emailServiceDtos)
    {

        await listValidator.ValidateAndThrowAsync(emailServiceDtos);
    
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(configure.Name, configure.EmailAddress));
        emailServiceDtos.EmailTos.ForEach(x => message.Bcc.Add(MailboxAddress.Parse(x)));
        message.Subject = emailServiceDtos.Subject!;
        message.Body =  new TextPart("html") { Text = emailServiceDtos.Body! };
        using var client = new SmtpClient();
        await client.ConnectAsync(configure.EmailProvider.HostEmailProvider, configure.EmailProvider.PortEmailProvider, MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(configure.EmailAddress, configure.Password);
        var result =await client.SendAsync(message);
        
        await client.DisconnectAsync(true);

    }
}