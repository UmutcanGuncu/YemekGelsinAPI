using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace YemekGelsin.WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DenemeController : ControllerBase
{
    [Authorize(Roles = "User")]
    [HttpGet]
    public IActionResult Deneme()
    {
        return Ok("Denedim");
    }
}