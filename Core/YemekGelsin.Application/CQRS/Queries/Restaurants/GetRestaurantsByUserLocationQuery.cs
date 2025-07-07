using MediatR;
using YemekGelsin.Application.CQRS.Results.Restaurants;

namespace YemekGelsin.Application.CQRS.Queries.Restaurants;

public class GetRestaurantsByUserLocationQuery(Guid userId) : IRequest<IEnumerable<GetRestaurantsByUserLocationQueryResult>>
{
    public Guid UserId { get; set; } = userId;
}