using Microsoft.EntityFrameworkCore;
using YemekGelsin.Domain.Entities.Common;

namespace Payment.Persistence.Contexts;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options):  base(options){}
    public DbSet<Domain.Entities.Payment> Payments { get; set; }
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
}