using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Results.Restaurants;

namespace YemekGelsin.Application.CQRS.Commands.Restaurants;

public class CreateRestaurantCommandRequest : IRequest<CreateRestaurantCommandResponse>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public Guid AppUserId { get; set; }
    public int Category { get; set; }
}