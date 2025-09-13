using CustomerService.AppDomain.CustomerAgg.Enum;

namespace Contracts.Dtos;

public class AddCustomerDto
{
    #region userInfo
    
    public string UserName { get; set; } = null!;
    //darsoratike user az ghabl dar system ma vojod dashte bashad ehtiaj be in etelat nist
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    //
    #endregion
    
    #region CustomerInfo
    public int Age { get; set; }
    public Gender Gender { get; set; }
    #endregion
    
    
}