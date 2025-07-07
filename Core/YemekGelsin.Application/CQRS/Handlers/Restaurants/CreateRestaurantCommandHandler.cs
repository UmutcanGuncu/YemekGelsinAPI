using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Restaurants;
using YemekGelsin.Application.CQRS.Results.Restaurants;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.CQRS.Handlers.Restaurants;

public class CreateRestaurantCommandHandler(IRestaurantService _restaurantService, IMapper _mapper) : IRequestHandler<CreateRestaurantCommandRequest, CreateRestaurantCommandResponse>
{
    public async Task<CreateRestaurantCommandResponse> Handle(CreateRestaurantCommandRequest request, CancellationToken cancellationToken)
    {
        var restaurant = _mapper.Map<Restaurant>(request);
        restaurant.CreatedAt = DateTime.UtcNow;
        var result = await _restaurantService.AddAsync(restaurant);
        return new CreateRestaurantCommandResponse()
        {
            Successed = result,
            Message = $"Restaurant {restaurant.Name} has been created"
        };
    }
}