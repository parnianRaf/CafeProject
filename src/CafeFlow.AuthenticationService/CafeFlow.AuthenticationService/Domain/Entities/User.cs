using Microsoft.AspNetCore.Identity;

namespace CafeFlow.AuthenticationService.Domain.Entities;

public class User : IdentityUser<Guid>
{
    private User()
    {
        Id = Guid.NewGuid();
    }

    public string FirstName { get;  private set; }
    public string LastName { get; private set; }




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