namespace YemekGelsin.Application.DTOs.RestaurantDtos.ResultDtos;

public class GetRestaurantsResultDTO
{
    public string RestaurantId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
}