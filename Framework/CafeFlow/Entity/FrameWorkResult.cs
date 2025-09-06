namespace CafeFlow.Framework.Entity;

public class FrameWorkResult(bool isValid = true, string message = "")
{

    public bool IsValid { get; } = isValid;
    public string Message { get;  } = message;
}