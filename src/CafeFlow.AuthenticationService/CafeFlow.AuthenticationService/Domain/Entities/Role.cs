using CafeFlow.AuthenticationService.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace CafeFlow.AuthenticationService.Domain.Entities;

public class Role:IdentityRole<Guid>
{
    private Role()
    {

    }

    public int Code { get; set; }



    public static Role GenerateRole(int code, string roleName , Guid? id = null )
    {
        return new()
        {
            Id = id ?? Guid.NewGuid(),
            Code = code,
            Name = roleName,
        };
    }
}