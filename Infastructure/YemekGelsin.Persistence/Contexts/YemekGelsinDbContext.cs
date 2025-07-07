using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Domain.Entities.Common;

namespace YemekGelsin.Persistence.Contexts;

public class YemekGelsinDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public YemekGelsinDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.Entries().ToList().ForEach(entry =>
        {
            if (entry.Entity is BaseEntity baseEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    baseEntity.CreatedAt = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    baseEntity.UpdatedAt = DateTime.Now;
                }
            }
        });
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ChangeTracker.Entries().ToList().ForEach(entry =>
        {
            if (entry.Entity is BaseEntity baseEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    baseEntity.CreatedAt = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    baseEntity.UpdatedAt = DateTime.Now;
                }
            }
        });
        return base.SaveChanges();
    }
}