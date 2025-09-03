using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeFlow.AuthenticationService.DataAccess.EntityConfiguration;

public class IdentityUserRoleTypeConfiguration:IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData( new IdentityUserRole<Guid>()
        {
            UserId = new Guid("954f01de-d4d7-7e89-3c58-8fcb5af4aa51"), 
            RoleId = new Guid("af5fd740-39e4-29f6-3e39-396b339487d4")

        });
    }
}