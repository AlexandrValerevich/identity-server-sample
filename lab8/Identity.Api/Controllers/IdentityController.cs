using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responces;
using Identity.Api.Models;
using Identity.Api.Quries.Requests;
using Identity.Api.Quries.Responces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IMediator _mediator;

    public IdentityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        LoginResponse responce = await _mediator.Send(request);

        if (!responce.IsSucceed)
        {
            return BadRequest(new AuthentificationFail
            {
                Errors = responce.Errors
            });
        }
        
        return Ok(new AuthentificationSuccess
        {
            Token = responce.Token
        });
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Reqistration([FromBody] RegistrationRequest request)
    {
        RegistrationResponse responce = await _mediator.Send(request);

        if (!responce.IsSucceed)
        {
            return BadRequest(new AuthentificationFail
            {
                Errors = responce.Errors
            });
        }
        
        return Ok(new AuthentificationSuccess
        {
            Token = responce.Token
        });
    }
}
