using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopDemo.Identity.Models;

namespace ShopDemo.Identity.DbContext;

public class ShopDemoIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public ShopDemoIdentityDbContext(DbContextOptions<ShopDemoIdentityDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ShopDemoIdentityDbContext).Assembly);
    }
}