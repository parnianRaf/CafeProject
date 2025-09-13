using CafeService.AppDomain.CafeAgg.Entity;
using CafeService.AppDomain.CafeAgg.ValueObjects;
using CafeService.SqlServerDataBase.Configuration.EntityConfiguration.CommonConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlServerDataBase.Configuration.EntityConfiguration;

public class CafeEntityTypeConfiguration: BaseEntityConfiguration<Cafe> 
{
    public override void Configure(EntityTypeBuilder<Cafe> builder)
    { 
        base.Configure(builder);
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(opt => !opt.IsDeleted);
        builder.OwnsOne(x => x.Address, a =>
        {
            a.Property(p => p.Value).HasColumnName("Address").HasMaxLength(350);
        });
        
        builder.OwnsOne(x => x.PhoneNumber, a =>
        {
            a.Property(p => p.Value).HasColumnName("PhoneNumber").HasMaxLength(15);
        });
        
  
        
       
    }
}