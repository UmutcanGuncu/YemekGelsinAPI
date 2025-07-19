using Microsoft.AspNetCore.Mvc;
using Order.Application.DTOs.Payments.RequestDtos;

namespace Payment.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> PaymentStartAsync()
    {
        return Ok();
    }
}