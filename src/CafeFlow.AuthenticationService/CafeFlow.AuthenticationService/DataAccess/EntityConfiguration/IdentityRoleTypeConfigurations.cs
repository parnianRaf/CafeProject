using CafeFlow.AuthenticationService.Domain.Entities;
using CafeFlow.AuthenticationService.Domain.Enums;
using CafeFlow.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeFlow.AuthenticationService.DataAccess.EntityConfiguration
{
    public class IdentityRoleTypeConfigurations : IEntityTypeConfiguration<Role>
    {
        private readonly string _privateString = "P@jjf234";

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasAlternateKey(x => x.Code);
            var roles = Enum.GetValues<RoleEnum>();
            roles.ToList().ForEach( role =>
            {
                var id = ExtensionMethods.GenerateDeterministicGuid(role.ToString(), _privateString);
                var roleEntity = Role.GenerateRole((int)role, role.ToString(), id);
                roleEntity.NormalizedName = role.ToString().ToUpper(); 
                builder.HasData(roleEntity);
            });
            
        }

    }
}