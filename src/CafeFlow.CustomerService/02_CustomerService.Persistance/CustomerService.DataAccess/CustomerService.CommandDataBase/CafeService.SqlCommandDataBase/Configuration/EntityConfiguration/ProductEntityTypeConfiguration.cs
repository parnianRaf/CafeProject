using CafeService.SqlCommandDataBase.Configuration.EntityConfiguration.CommonConfiguration;
using CustomerService.AppDomain.ProductAgg.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlCommandDataBase.Configuration.EntityConfiguration;

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