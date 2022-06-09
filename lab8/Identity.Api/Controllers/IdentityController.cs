using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responses;
using Identity.Api.Interfaces;
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
        return await HandleRequest<LoginRequest, LoginResponse>(request);
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Reqistration([FromBody] RegistrationRequest request)
    {
        return await HandleRequest<RegistrationRequest, RegistrationResponse>(request);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshTokenRequest request)
    {
        return await HandleRequest<RefreshTokenRequest, RefreshTokenResponse>(request);
    }

    private async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TResponse : IAuthResponse
        where TRequest : IRequest<TResponse>
    {
        var responce = await _mediator.Send(request);

        if (!responce.IsSucceed)
        {
            return BadRequest(new AuthentificationFail
            {
                Errors = responce.Errors
            });
        }

        return Ok(new AuthentificationSuccess
        {
            AccessToken = responce.AccessToken,
            RefreshToken = responce.RefreshToken
        });
    }
}
