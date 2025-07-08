using AutoMapper;
using YemekGelsin.Application.CQRS.Commands.Auths;
using YemekGelsin.Application.CQRS.Commands.Orders;
using YemekGelsin.Application.CQRS.Commands.Products;
using YemekGelsin.Application.CQRS.Commands.Restaurants;
using YemekGelsin.Application.CQRS.Results.Auths;
using YemekGelsin.Application.CQRS.Results.Comments;
using YemekGelsin.Application.DTOs.AuthDtos;
using YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Domain.Enums;

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
        CreateMap<CreateRestaurantCommandRequest,Restaurant>()
            .ForMember(dest=> dest.Category
            ,opt => opt.MapFrom(src => (RestaurantCategory)src.Category));
        CreateMap<UpdateRestaurantCommandRequest,Restaurant>()
            .ForMember(dest=> dest.Category
                ,opt => opt.MapFrom(src => (RestaurantCategory)src.Category));
        CreateMap<CreateProductCommandRequest, Product>();
        CreateMap<UpdateProductCommandRequest, Product>();
        CreateMap<CreateCommentCommandResponse, Comment>();
        CreateMap<UpdateCommentCommandResponse, Comment>();
        CreateMap<CreateOrderCommandRequest, CreateOrderDto>();
    }
}