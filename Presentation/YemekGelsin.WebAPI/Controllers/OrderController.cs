using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekGelsin.Application.CQRS.Commands.Orders;

namespace YemekGelsin.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> DeleteOrder(DeleteOrderCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        if (result.Successed)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateOrder(UpdateOrderCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        if (result.Successed)
            return Ok(result);
        return BadRequest(result);
    }
}