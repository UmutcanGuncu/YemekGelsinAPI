using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Restaurants;
using YemekGelsin.Application.CQRS.Results.Restaurants;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.CQRS.Handlers.Restaurants;

public class UpdateRestaurantCommandHandler(IRestaurantService restaurantService, IMapper mapper) : IRequestHandler<UpdateRestaurantCommandRequest, UpdateRestaurantCommandResponse>
{
    public async Task<UpdateRestaurantCommandResponse> Handle(UpdateRestaurantCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<Restaurant>(request);
        var result =  await restaurantService.UpdateAsync(map);
        var message = result == true ? "Restoran Bilgisi Başarıyla Güncellendi" : "Restoran Bilgisi Güncellenirken Hata Meydana Geldi";
        return new UpdateRestaurantCommandResponse()
        {
            Successed = result,
            Message = message
        };
    }
}