namespace CafeFlow.AuthenticationService.AppService.Contracts.Dto.CommonDto;

public class StatusResultDto
{
    public bool IsValid { get; set; }
    public string? Message { get; set; }
}