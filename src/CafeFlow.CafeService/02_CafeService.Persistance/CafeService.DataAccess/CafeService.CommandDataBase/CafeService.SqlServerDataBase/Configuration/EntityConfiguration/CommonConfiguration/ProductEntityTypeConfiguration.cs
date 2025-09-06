using CafeService.AppDomain.ProductAgg.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlServerDataBase.Configuration.EntityConfiguration.CommonConfiguration;

public class ProductEntityTypeConfiguration:BaseEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Description).HasMaxLength(200);
    }
}