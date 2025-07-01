using YemekGelsin.Domain.Entities.Common;

namespace YemekGelsin.Domain.Entities;

public class Restaurant : BaseEntity
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public AppUser AppUser { get; set; }
    public Guid AppUserId { get; set; } // restoran sahibinin tutulması
}