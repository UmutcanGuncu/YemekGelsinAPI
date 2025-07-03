using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YemekGelsin.Application.Abstractions.Token;
using YemekGelsin.Application.Abstractions.Services;

namespace YemekGelsin.Infastructure.Services.Token;

public class TokenService : ITokenHandler
{
    private readonly IConfiguration _configuration;
    private readonly IRoleService _roleService;

    public TokenService(IConfiguration configuration, IRoleService roleService)
    {
        _configuration = configuration;
        _roleService = roleService;
    }

    public async Task<Application.DTOs.Token> CreateAccessToken(string userId)
    {
        Application.DTOs.Token token = new();
        //Security key'in simetriğini alırız
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        //şifrelenmiş kimliği oluştur
        SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256Signature);
        // Oluşturulacak token ayarlarını veririz
        token.Expiration = DateTime.UtcNow.AddDays(5); // 5 gün ömürlü olsun
        var roleClaims = await _roleService.GetUserRolesAsync(userId);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.Union(roleClaims);
        JwtSecurityToken securityToken = new(
            audience: _configuration["JWT:Audience"],
            issuer: _configuration["JWT:Issuer"],
            signingCredentials: signingCredentials,
            claims: claims,
            expires: token.Expiration,
            notBefore: DateTime.UtcNow); //üretildiği andan itibaren başlar ;
        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);
        token.RefreshToken =  CreateRefreshToken();;
        return token;
    }

    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }
}