using CafeFlow.Framework.ExceptionAgg.Exception;

namespace CafeService.AppDomain.CafeAgg.ValueObjects;

public class Address
{
    private Address()
    {
        
    }
    public Address(string? mainStreet, string? street , string? postalCode , int? numberPlate)
    {
        IsValidAddress(mainStreet, street, postalCode, numberPlate);
        Value = NormalizedAddress(mainStreet, street, postalCode, numberPlate!.Value);
    }

    public string Value { get; set; }

    private string NormalizedAddress(string? mainStreet, string? street , string? postalCode , int numberPlate)
    {
        return string.Join(" - " , new string[]
            {!string.IsNullOrEmpty(mainStreet) ? mainStreet :""
                ,(!string.IsNullOrEmpty(street) ? street :"")
                , (int.IsEvenInteger(numberPlate) ? numberPlate.ToString() :"")}
                .Where(x => !string.IsNullOrEmpty(x)));
    }

    private void IsValidAddress(string? mainStreet, string? street, string? postalCode, int? numberPlate)
    {
        if (numberPlate == null)
            throw CommonExceptionDto.GenerateCommonException("number plate should not be null");
        if (postalCode == null)
            throw CommonExceptionDto.GenerateCommonException("postal code should not be null");
        if(!IsValidPostalCode(postalCode))
            throw CommonExceptionDto.GenerateCommonException("postal code is not valid");

    }

    private bool IsValidPostalCode(string postalCode)
    {
        if (!int.TryParse(postalCode, out int _))
            return false;
        if (postalCode.Length != 10)
            return false;
        
        // ye seri shareyete dg ham dare
        
        //
        return true;
    }
    
    
}