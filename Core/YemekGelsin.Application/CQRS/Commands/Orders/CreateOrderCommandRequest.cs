using MediatR;
using YemekGelsin.Application.CQRS.Results.Orders;

namespace YemekGelsin.Application.CQRS.Commands.Orders;

public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
{
    public Guid RestaurantId { get; set; }
    public Guid UserId { get; set; }
    public List<ProductViewModel> Products { get; set; }
}
public class ProductViewModel
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
   
}