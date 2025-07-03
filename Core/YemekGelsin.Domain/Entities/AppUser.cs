using Microsoft.AspNetCore.Identity;
using YemekGelsin.Domain.Enums;

namespace YemekGelsin.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender? Gender { get; set; }
    public string? Age { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public Restaurant Restaurant { get; set; } // Her kullanıcının tek restoranı olur
}