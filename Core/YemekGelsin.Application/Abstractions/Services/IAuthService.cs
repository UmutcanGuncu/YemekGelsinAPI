using YemekGelsin.Application.DTOs.AuthDtos;

namespace YemekGelsin.Application.Abstractions.Services;

public interface IAuthService
{
    Task<LoginResultDTO> LoginAsync(LoginDTO loginDTO);
    Task<RegisterResultDTO> RegisterAsync(RegisterDTO dto);
    Task<GoogleLoginResultDTO> GoogleLoginAsync(GoogleLoginDTO googleLoginDTO);
}