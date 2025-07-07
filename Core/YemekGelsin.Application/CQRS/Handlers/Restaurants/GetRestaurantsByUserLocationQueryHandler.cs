using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Queries.Restaurants;
using YemekGelsin.Application.CQRS.Results.Restaurants;

namespace YemekGelsin.Application.CQRS.Handlers.Restaurants;

public class GetRestaurantsByUserLocationQueryHandler(IRestaurantService service) : IRequestHandler<GetRestaurantsByUserLocationQuery, IEnumerable<GetRestaurantsByUserLocationQueryResult>>
{
    public async Task<IEnumerable<GetRestaurantsByUserLocationQueryResult>> Handle(GetRestaurantsByUserLocationQuery request, CancellationToken cancellationToken)
    {
        var results = await service.GetRestaurantsByUserLocationAsync(request.UserId);
        return results.Select(x=> new GetRestaurantsByUserLocationQueryResult
        {
            Address = x.Address,
            City = x.City,
            District = x.District,
            Name = x.Name,
            PhoneNumber = x.PhoneNumber,
            RestaurantId = x.RestaurantId
        });
    }
}