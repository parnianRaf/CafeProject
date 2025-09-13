using CafeFlow.Framework.ExceptionAgg.Exception;

namespace CustomerService.AppDomain.CafeAgg.ValueObjects;

public class PhoneNumber
{
    private PhoneNumber(){}
     public PhoneNumber(string? phoneNumber)
    {
        IsValidPhoneNumber(phoneNumber);
        Value = NormalizedPhoneNumber(phoneNumber!);
    }
    public string Value { get; set; }

    private void IsValidPhoneNumber(string? phoneNumber)
    {
        if(phoneNumber == null)
            throw CommonExceptionDto.GenerateCommonException("phone number should not be null");
        if(!int.TryParse(phoneNumber[^1..], out _))
            throw CommonExceptionDto.GenerateCommonException("phone number should be an integer");
    }

    private string NormalizedPhoneNumber(string phoneNumber)
    {
        return $"+98{phoneNumber[^11..]}";
    }
    
    
}