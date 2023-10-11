using Microsoft.EntityFrameworkCore;
using ShopDemo.Domain;
using ShopDemo.Domain.Common;

namespace ShopDemo.Infrastructure.DatabaseContext;

public class ShopDatabaseContext : DbContext
{
    public ShopDatabaseContext(DbContextOptions<ShopDatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}