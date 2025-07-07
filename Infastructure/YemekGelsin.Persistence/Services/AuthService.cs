using AutoMapper;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.Abstractions.Token;
using YemekGelsin.Application.CQRS.Commands.Auths;
using YemekGelsin.Application.DTOs.AuthDtos;
using YemekGelsin.Domain.Entities;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace YemekGelsin.Persistence.Services;

public class AuthService  : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;


    public AuthService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, IMapper mapper, IRoleService roleService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenHandler = tokenHandler;
        _signInManager = signInManager;
        _mapper = mapper;
        _roleService = roleService;
    }

    public async Task<LoginResultDTO> LoginAsync(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByEmailAsync(loginDTO.Email);
        if (user == null)
        {
            return new()
            {   
                Succeeded = false,
                Message = "User not found",
                
            };
        }
        SignInResult result =  await _signInManager.CheckPasswordSignInAsync(user,loginDTO.Password, false);
        if (result.Succeeded)
        {
            await _signInManager.PasswordSignInAsync(user, loginDTO.Password, true, false);
            var token = await _tokenHandler.CreateAccessToken(user.Id.ToString());
            return new()
            {
                Succeeded = true,
                Message = "User successfully logged in",
                Token = token,
                UserId = user.Id.ToString(),
            };
        }

        return new()
        {
            Succeeded = false,
            Message = "User not found",
        };
    }

    public async Task<RegisterResultDTO> RegisterAsync(RegisterDTO dto)
    {
        var appUser = _mapper.Map<AppUser>(dto);
        appUser.UserName = dto.Email;
        var result = await _userManager.CreateAsync(appUser, dto.Password);
        if (result.Succeeded)
        {
            AppUser user = await _userManager.FindByEmailAsync(dto.Email);
            await _roleService.AssingRoleAsync(user, "User");
            return new()
            {
                IsSuccess = true,
                Message = "Kayıt işlemi Başarıyla Tamamlandı"
            };
        }

        return new ()
        {
            IsSuccess = false,
            Message = result.Errors.First().Description
        };
    }

    public async Task<GoogleLoginResultDTO> GoogleLoginAsync(GoogleLoginDTO googleLoginDTO)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { "487840124789-u67bq4e0ko94s23bgjen8k0o6hgl1vlk.apps.googleusercontent.com" }
        };
        var payload = await GoogleJsonWebSignature.ValidateAsync(googleLoginDTO.IdToken, settings);
        var info = new UserLoginInfo(googleLoginDTO.Provider, payload.Subject, googleLoginDTO.Provider);
        AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
        bool result = user != null;
        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                user = new()
                {
                    Id = Guid.NewGuid(),
                    Email = payload.Email,
                    UserName = payload.Email,
                    FirstName = payload.Name,
                };
                var identityResult  =  await _userManager.CreateAsync(user);
                result = identityResult.Succeeded;
            }
            else
            {
                await _signInManager.SignInAsync(user, false);
                var token = await _tokenHandler.CreateAccessToken(user.Id.ToString());
                return new()
                {
                    Succeeded = true,
                    Message = "User successfully logged in",
                    Token = token,
                    UserId = user.Id.ToString(),
                };
            }
            
        }

        if (result)
        {
            await _userManager.AddLoginAsync(user, info);
            await _roleService.AssingRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, false);
            var token = await _tokenHandler.CreateAccessToken(user.Id.ToString());
            return new()
            {
                Succeeded = true,
                Message = "User successfully logged in",
                Token = token,
                UserId = user.Id.ToString(),
            };
        }

        return new()
        {
            Succeeded = false,
            Message = "User not Login",
        };
    }
}