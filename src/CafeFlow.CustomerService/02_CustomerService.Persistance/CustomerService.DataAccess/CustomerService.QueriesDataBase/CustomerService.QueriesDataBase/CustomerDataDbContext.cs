using CustomerService.AppDomain.CafeAgg.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.QueriesDataBase;

public class CustomerDataDbContext:DbContext
{
    public DbSet<Cafe> Cafes { get; set; }
    public CustomerDataDbContext(DbContextOptions<CustomerDataDbContext> options):base(options)
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