using CafeFlow.AuthenticationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeFlow.AuthenticationService.DataAccess.EntityConfiguration;

public class UserEntityTypeConfiguration :IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
         builder.Property(x => x.FirstName)
             .IsRequired().HasMaxLength(50);
         
         builder.Property(x => x.LastName)
             .IsRequired().HasMaxLength(50);

         var user = new User()
         {
             FirstName = "parnain",
             LastName = "rafiee",
             UserName = "parnain",
             NormalizedUserName = "PARNIAN",
             Email = null,
             NormalizedEmail = null,
             EmailConfirmed = false,
             PasswordHash = "AQAAAAIAAYagAAAAEHj8ecEvsbmeGMn9WVQexx8gfga0Minqk17Ru6FZ4PndXrclvY7hXyB1afisD+VTnA==", // string
             SecurityStamp = "XZ5NQPYPMFCFQODGDZYWTRERHEO55TD2",
             ConcurrencyStamp = "68abbacc-deb9-4c1d-a26c-805e36449111",
             PhoneNumber = null,
             PhoneNumberConfirmed = false,
             TwoFactorEnabled = false,
             LockoutEnd = null,
             LockoutEnabled = true,
             AccessFailedCount = 0
         };

         builder.HasData(user);
    }
}