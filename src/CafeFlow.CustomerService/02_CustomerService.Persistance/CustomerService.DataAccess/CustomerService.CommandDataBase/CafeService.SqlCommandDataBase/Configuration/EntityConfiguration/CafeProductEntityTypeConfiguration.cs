using CafeService.SqlCommandDataBase.Configuration.EntityConfiguration.CommonConfiguration;
using CustomerService.AppDomain.CafeProductAgg.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlCommandDataBase.Configuration.EntityConfiguration;

public class CafeProductEntityTypeConfiguration:BaseEntityConfiguration<CafeProduct>
{
    public override void Configure(EntityTypeBuilder<CafeProduct> builder)
    { 
        base.Configure(builder);
        builder.HasIndex(x => x.CafeId)
            .HasDatabaseName("IX_CafeIdIndex");

    }
}