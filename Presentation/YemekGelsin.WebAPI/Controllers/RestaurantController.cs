using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekGelsin.Application.CQRS.Commands.Restaurants;
using YemekGelsin.Application.CQRS.Queries.Restaurants;

namespace YemekGelsin.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class RestaurantController(IMediator mediator) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetRestaurantsByUserLocation(Guid userId)
    {
        var results = await mediator.Send(new GetRestaurantsByUserLocationQuery(userId));
        return Ok(results);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> DeleteRestaurant(DeleteRestaurantCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateRestaurant(UpdateRestaurantCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        if (result.Successed)
            return Ok(result);
        return BadRequest(result);
    }
}