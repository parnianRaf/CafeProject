using CafeService.AppDomain.CafeProductAgg.Entity;
using CafeService.AppDomain.ProductAgg.Product;
using CafeService.SqlServerDataBase.Configuration.EntityConfiguration.CommonConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlServerDataBase.Configuration.EntityConfiguration;

public class CafeProductEntityTypeConfiguration:BaseEntityConfiguration<CafeProduct>
{
    public override void Configure(EntityTypeBuilder<CafeProduct> builder)
    { 
        base.Configure(builder);
        builder.HasIndex(x => x.CafeId)
            .HasDatabaseName("IX_CafeIdIndex");

    }
}