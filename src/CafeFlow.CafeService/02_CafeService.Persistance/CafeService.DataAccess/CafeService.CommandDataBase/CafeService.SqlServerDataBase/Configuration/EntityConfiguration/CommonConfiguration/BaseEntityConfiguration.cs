using CafeService.AppDomain.CommonEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlServerDataBase.Configuration.EntityConfiguration.CommonConfiguration;

public class BaseEntityConfiguration:IEntityTypeConfiguration<BaseClass>
{
    public void Configure(EntityTypeBuilder<BaseClass> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(opt => !opt.IsDeleted);
    }
}