using YemekGelsin.Application.CQRS.Commands.Orders;

namespace YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;

public class CreateOrderDto
{
    public Guid RestaurantId { get; set; }
    public Guid UserId { get; set; }
    public List<ProductViewModel> Products { get; set; }
}