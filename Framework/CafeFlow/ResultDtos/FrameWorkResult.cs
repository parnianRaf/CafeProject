namespace CafeFlow.Framework.ResultDtos;

public class FrameWorkResult(bool isValid = true, string message = "")
{

    public bool IsValid { get; } = isValid;
    public string Message { get;  } = message;
}