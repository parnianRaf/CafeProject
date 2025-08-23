using Microsoft.AspNetCore.Identity;

namespace CafeFlow.AuthenticationService.Domain.Entities;

public class Role:IdentityRole<Guid>
{
    public Role()
    {
        Id = Guid.NewGuid();
    }
}