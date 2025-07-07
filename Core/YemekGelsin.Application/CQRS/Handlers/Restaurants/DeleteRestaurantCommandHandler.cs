using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Restaurants;
using YemekGelsin.Application.CQRS.Results.Restaurants;

namespace YemekGelsin.Application.CQRS.Handlers.Restaurants;

public class DeleteRestaurantCommandHandler(IRestaurantService restaurantService) : IRequestHandler<DeleteRestaurantCommandRequest, DeleteRestaurantCommandResponse>
{
    public async Task<DeleteRestaurantCommandResponse> Handle(DeleteRestaurantCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await restaurantService.RemoveAsync(request.Id);
        string message = result == true ? "Restoran başarıyla silindi" : "Restoran silinirken hata meydana geldi";
        return new()
        {
            Success = result,
            Message = message
        };
    }
}