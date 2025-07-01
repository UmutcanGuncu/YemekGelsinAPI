using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Persistence.Contexts;

namespace YemekGelsin.Persistence.Services;

public class RestaurantService(YemekGelsinDbContext context) : GenericService<Restaurant>(context), IRestaurantService
{
    
}