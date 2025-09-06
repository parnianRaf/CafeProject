using Microsoft.EntityFrameworkCore;
using CafeFlow.AuthenticationService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CafeFlow.AuthenticationService.DataAccess.EntityConfiguration;

namespace CafeFlow.AuthenticationService.DataAccess;

public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext<User, Role, Guid>(options)
{
    public override DbSet<User> Users { get; set; } 
    public override DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IdentityRoleTypeConfigurations());
        base.OnModelCreating(modelBuilder);
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        modelBuilder.ApplyConfiguration(new IdentityUserRoleTypeConfiguration());

    }
}