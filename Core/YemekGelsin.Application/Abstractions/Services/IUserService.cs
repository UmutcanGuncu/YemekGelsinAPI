using YemekGelsin.Application.DTOs.UserDtos.RequestDtos;
using YemekGelsin.Application.DTOs.UserDtos.ResultDtos;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.Abstractions.Services;

public interface IUserService
{
    Task<GetUserAddressResultDto> GetUserAddressAsync(GetUserAddressDto userAddressDto);
}