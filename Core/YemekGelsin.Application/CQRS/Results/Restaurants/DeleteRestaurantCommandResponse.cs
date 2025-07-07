namespace YemekGelsin.Application.CQRS.Results.Restaurants;

public class DeleteRestaurantCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}