using MediatR;
using YemekGelsin.Application.CQRS.Results.Restaurants;

namespace YemekGelsin.Application.CQRS.Commands.Restaurants;

public class DeleteRestaurantCommandRequest(Guid id) : IRequest<DeleteRestaurantCommandResponse>
{
    public Guid Id { get; set; } = id;
}