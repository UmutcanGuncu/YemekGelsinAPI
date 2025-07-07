using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.DTOs.UserDtos.RequestDtos;
using YemekGelsin.Application.DTOs.UserDtos.ResultDtos;
using YemekGelsin.Persistence.Contexts;

namespace YemekGelsin.Persistence.Services;

public class UserService(YemekGelsinDbContext context) : IUserService
{
    public async Task<GetUserAddressResultDto> GetUserAddressAsync(GetUserAddressDto userAddressDto)
    {
        var result = await context.Users.FindAsync(userAddressDto.Id);
        return new GetUserAddressResultDto()
        {
            Address = result.Address,
            City = result.City,
            District = result.District
        };
    }
}