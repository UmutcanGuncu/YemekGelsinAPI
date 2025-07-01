using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Persistence.Contexts;

public class YemekGelsinDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public YemekGelsinDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
}