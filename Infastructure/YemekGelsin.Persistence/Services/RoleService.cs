using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Persistence.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<bool> AssingRoleAsync(AppUser user, string roleName)
    {
        if (user == null)
            return false;

        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            await _roleManager.CreateAsync(new AppRole { Name = roleName });
            
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        if (userRoles.Contains(roleName))  // Kullanıcının zaten bu rolü var mı?
            return true;  // Zaten bu role sahipse tekrar eklemeye gerek yok.

        var result = await _userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded;
    }

    public async Task<IEnumerable<Claim>> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaim =  roles.Select(role => new Claim(ClaimTypes.Role, role));
            return roleClaim;
        }
        return new List<Claim>();
    }

    public Task<bool> UpdateUserRolesAsync(AppUser user, IEnumerable<Claim> roles)
    {
        throw new NotImplementedException();
    }
}