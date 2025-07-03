using System.Security.Claims;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.Abstractions.Services;

public interface IRoleService
{
    Task<bool> AssingRoleAsync(AppUser user , string roleName);
    Task<IEnumerable<Claim>> GetUserRolesAsync(string userId);
    Task<bool> UpdateUserRolesAsync(AppUser user, IEnumerable<Claim> roles);
}