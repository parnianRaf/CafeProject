using CafeService.AppDomain.CafeAgg.Cafe;
using CafeService.AppDomain.ProductAgg.Product;
using CafeService.SqlServerDataBase.Configuration;
using CafeService.SqlServerDataBase.Configuration.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CafeService.SqlServerDataBase.Context;

public class CafeDbContext(DbContextOptions<CafeDbContext> options):DbContext(options)
{
    public DbSet<Cafe> Cafes { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(CafeEntityTypeConfiguration).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}