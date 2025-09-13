using CustomerService.AppDomain.CommonEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeService.SqlCommandDataBase.Configuration.EntityConfiguration.CommonConfiguration;

public class BaseEntityConfiguration<T>:IEntityTypeConfiguration<T> where T :BaseClass
{

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(opt => !opt.IsDeleted);
    }
}