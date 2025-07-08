using YemekGelsin.Domain.Entities.Common;

namespace YemekGelsin.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Price { get; set; }
    public bool IsActive { get; set; }
    public Restaurant Restaurant { get; set; }
    public Guid RestaurantId { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}