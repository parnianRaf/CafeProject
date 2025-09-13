using CafeService.AppDomain.CafeAgg.Entity;
using Microsoft.EntityFrameworkCore;

namespace CafeService.QueriesDataBase;

public class CafeDataDbContext:DbContext
{
    public DbSet<Cafe> Cafes { get; set; }
    public CafeDataDbContext(DbContextOptions<CafeDataDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}