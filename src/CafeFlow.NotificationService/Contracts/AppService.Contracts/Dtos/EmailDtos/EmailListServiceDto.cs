namespace CafeFlow.NotifcationService.Contracts.AppService.Contracts.Dtos.EmailDtos;

public class EmailListServiceDto
{
    public EmailListServiceDto()
    {
        EmailTos = new List<string?>();
    }
    public List<string?> EmailTos { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}