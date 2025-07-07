using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekGelsin.Application.CQRS.Commands.Comments;

namespace YemekGelsin.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class CommentController(IMediator mediator) : ControllerBase
{
    
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateComment(CreateCommentCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> DeleteComment(DeleteCommentCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        if (result.Successed)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateComment(UpdateCommentCommandRequest restaurant)
    {
        var result = await mediator.Send(restaurant);
        if (result.Successed)
            return Ok(result);
        return BadRequest(result);
    }
    
}