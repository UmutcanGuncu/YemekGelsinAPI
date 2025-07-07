using MediatR;
using YemekGelsin.Application.CQRS.Results.Orders;

namespace YemekGelsin.Application.CQRS.Commands.Orders;

public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
{
    public Guid RestaurantId { get; set; }
    public Guid UserId { get; set; }
}