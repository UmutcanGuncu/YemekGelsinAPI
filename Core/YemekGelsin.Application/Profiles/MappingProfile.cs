using AutoMapper;
using YemekGelsin.Application.CQRS.Commands.Auths;
using YemekGelsin.Application.CQRS.Results.Auths;
using YemekGelsin.Application.DTOs.AuthDtos;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommandRequest, RegisterDTO>();
        CreateMap<RegisterDTO, RegisterCommandRequest>();
        CreateMap<RegisterResultDTO, RegisterCommandResponse>();
        CreateMap<RegisterDTO, AppUser>();
        CreateMap<AppUser, RegisterDTO>();
        CreateMap<LoginCommandRequest, LoginDTO>();
        CreateMap<LoginResultDTO, LoginCommandResponse>();
        CreateMap<GoogleLoginCommandRequest, GoogleLoginDTO>();
        CreateMap<GoogleLoginResultDTO, GoogleLoginCommandResponse>();
    }
}