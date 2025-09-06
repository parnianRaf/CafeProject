using CafeService.AppDomain.CafeAgg.Cafe;
using CafeService.AppDomain.CafeAgg.ValueObjects;
using CafeService.SqlServerDataBase.Configuration.EntityConfiguration.CommonConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlServerDataBase.Configuration.EntityConfiguration;

public class CafeEntityTypeConfiguration:BaseEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Cafe> builder)
    {
        builder.Property(x => x.Address)
            .HasField(nameof(Address.Value));
        
        builder.Property(x => x.PhoneNumber)
            .HasField(nameof(PhoneNumber.Value));
        
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(100);
        
        builder.Property(x => x.Address).
            HasMaxLength(350);
    }
}