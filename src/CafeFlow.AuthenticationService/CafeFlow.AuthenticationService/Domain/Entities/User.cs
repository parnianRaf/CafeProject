using Microsoft.AspNetCore.Identity;

namespace CafeFlow.AuthenticationService.Domain.Entities;

public class User : IdentityUser<Guid>
{
    private User()
    {
        base.Id = Guid.NewGuid();
    }
    
    
    // i assure it is not null , i have validator to check its not null

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;


    public static User GenerateUser(string firstName, string lastName , string userName , string email)
    {
        return new ()
        {
            FirstName = firstName,
            LastName = lastName,
            UserName = userName,
            Email = email
        };
    }
    
}