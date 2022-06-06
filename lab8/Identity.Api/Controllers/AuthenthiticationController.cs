using Identity.Api.Quries.Requests;
using Identity.Api.Quries.Responces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorizeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AutorizeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginRequest loginRequest)
    {
        LoginResponse reponse = await _mediator.Send(loginRequest);
        return Ok(reponse);
    }

    [Authorize]
    [HttpGet("data")]
    public IActionResult Data()
    {
        return Ok(new { message = "Hello World!" });
    }
}
