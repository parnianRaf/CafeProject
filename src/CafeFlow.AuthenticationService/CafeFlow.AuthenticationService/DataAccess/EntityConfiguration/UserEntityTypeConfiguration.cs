using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.Framework.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeFlow.AuthenticationService.DataAccess.EntityConfiguration;

public class UserEntityTypeConfiguration :IEntityTypeConfiguration<User>
{

    private readonly string _privateString = "User432#$!jnfs";

    public void Configure(EntityTypeBuilder<User> builder)
    {
         builder.Property(x => x.FirstName)
             .IsRequired().HasMaxLength(50);
         
         builder.Property(x => x.LastName)
             .IsRequired().HasMaxLength(50);

         var users =UserDataSeed();
         users.ToList().ForEach(user => builder.HasData(user));
    }

    private IList<User> UserDataSeed()
    {
        var users = new List<User>();
        var user = User.GenerateUser("Parnian", "Rafie", "parnian" , "rafieparnian@gmail.com");
        user.NormalizedUserName = "PARNIAN";
        user.PasswordHash = "AQAAAAIAAYagAAAAEHj8ecEvsbmeGMn9WVQexx8gfga0Minqk17Ru6FZ4PndXrclvY7hXyB1afisD+VTnA=="; // string
        user.SecurityStamp = "XZ5NQPYPMFCFQODGDZYWTRERHEO55TD2";
        user.ConcurrencyStamp = "68abbacc-deb9-4c1d-a26c-805e36449111";
        user.Id = ExtensionMethods.GenerateDeterministicGuid(user.UserName! , _privateString);
        
        users.Add(user);

        return users;
    }
}