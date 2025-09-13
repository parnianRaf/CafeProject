using System.Security.Claims;
using CafeService.AppDomain.CafeAgg.Entity;
using CafeService.AppDomain.CommonEntity;
using CafeService.AppDomain.ProductAgg.Product;
using CafeService.SqlServerDataBase.Configuration.EntityConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CafeService.SqlServerDataBase.Context;

public class CafeDbContext:DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CafeDbContext(DbContextOptions<CafeDbContext> options,IHttpContextAccessor accessor):base(options)
    {
        _httpContextAccessor = accessor; 
    }
    
    public DbSet<Cafe> Cafes { get; set; }
    public DbSet<Product> Products { get; set; }

    public override int SaveChanges()
    {
        ApplyAuditInfo();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ApplyAuditInfo();
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CafeEntityTypeConfiguration).Assembly, (obj)=> !obj.IsAbstract);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    
    private void ApplyAuditInfo()
    {
        var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var userId = Guid.TryParse(userIdString, out var guid) ? guid : Guid.Empty;

        foreach (var entry in ChangeTracker.Entries<BaseClass>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreatedBy = userId;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.Now;
                    entry.Entity.ModifiedBy = userId;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = DateTime.Now;
                    entry.Entity.DeletedBy = userId;
                    break;
            }
        }
    }
}