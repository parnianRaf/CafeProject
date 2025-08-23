using CafeFlow.AuthenticationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeFlow.AuthenticationService.DataAccess.EntityConfiguration
{
    public class IdentityRoleTypeConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role() { Id = new Guid("241159aa-82df-4fe5-8929-79307ed6ddee"), Name = "Admin", NormalizedName = "ADMIN" },
                new Role() { Id = new Guid("fab49e00-3bf2-4493-9e20-df058c655def"), Name = "Barista", NormalizedName = "BARISTA" },
                new Role() { Id = new Guid("d975f377-e4af-4dc3-a1fd-b4fa084f07f8"), Name = "Customer", NormalizedName = "CUSTOMER" }
            );
        }
    }
}