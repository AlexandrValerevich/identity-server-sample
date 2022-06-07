using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responces;
using Identity.Api.Quries.Requests;
using Identity.Api.Quries.Responces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AutorizeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AutorizeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        LoginResponse reponse = await _mediator.Send(loginRequest);
        return Ok(reponse);
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Reqistration([FromBody] RegistrationRequest request)
    {
        RegistrationResponse responce = await _mediator.Send(request);
        return Ok(responce);
    }
}
    