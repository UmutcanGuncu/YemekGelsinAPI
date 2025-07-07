using YemekGelsin.Application.DTOs.RestaurantDtos.ResultDtos;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.Abstractions.Services;

public interface IRestaurantService : IGenericService<Restaurant>
{
    Task<IEnumerable<GetRestaurantsResultDTO>> GetRestaurantsByUserLocationAsync(Guid userId);

}