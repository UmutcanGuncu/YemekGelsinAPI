using YemekGelsin.Domain.Entities.Common;

namespace YemekGelsin.Domain.Entities;

public class Comment : BaseEntity
{
    public Restaurant Restaurant { get; set; }
    public Guid RestaurantId { get; set; }
    public AppUser User { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Score { get; set; }
}