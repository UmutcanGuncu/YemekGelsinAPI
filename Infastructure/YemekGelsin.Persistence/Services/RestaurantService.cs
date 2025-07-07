using Microsoft.EntityFrameworkCore;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.DTOs.RestaurantDtos.ResultDtos;
using YemekGelsin.Application.DTOs.UserDtos.RequestDtos;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Persistence.Contexts;

namespace YemekGelsin.Persistence.Services;

public class RestaurantService(YemekGelsinDbContext context, IUserService userService) : GenericService<Restaurant>(context), IRestaurantService
{
    public async Task<IEnumerable<GetRestaurantsResultDTO>> GetRestaurantsByUserLocationAsync(Guid userId)
    {
       var userAddressResult = await userService.GetUserAddressAsync(new GetUserAddressDto(userId));
       var result = await context.Restaurants.
           Where(x=> x.City == userAddressResult.City && x.District == userAddressResult.District).
           ToListAsync();
       return result.Select(x=> new GetRestaurantsResultDTO()
       {
           RestaurantId = x.Id.ToString(),
           Name = x.Name,
           PhoneNumber = x.PhoneNumber,
           Address = x.Address,
           City = x.City,
           District = x.District
           
       });
    }
}