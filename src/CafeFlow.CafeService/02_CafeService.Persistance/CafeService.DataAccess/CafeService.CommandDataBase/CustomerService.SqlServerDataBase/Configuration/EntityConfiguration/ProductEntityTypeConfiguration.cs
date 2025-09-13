using CafeService.AppDomain.ProductAgg.Product;
using CafeService.SqlServerDataBase.Configuration.EntityConfiguration.CommonConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlServerDataBase.Configuration.EntityConfiguration;

public class ProductEntityTypeConfiguration:BaseEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    { 
        base.Configure(builder);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.ProductCode).HasMaxLength(200);
    }
}