using YemekGelsin.Domain.Entities.Common;
using YemekGelsin.Domain.Enums;

namespace YemekGelsin.Domain.Entities;

public class Order : BaseEntity
{
    public Restaurant Restaurant { get; set; }
    public Guid RestaurantId { get; set; }
    public AppUser User { get; set; }
    public Guid UserId { get; set; }
    public OrderStatus Status { get; set; }
    
}