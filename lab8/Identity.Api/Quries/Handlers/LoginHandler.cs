using Identity.Api.Quries.Requests;
using Identity.Api.Quries.Responces;
using Identity.BL.Interfaces;
using MediatR;

namespace Identity.Api.Quries.Handlers;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly ITokenService _tokenService;

    public LoginHandler(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var token = _tokenService.CreateAccessToken(request.Email);
        return Task.FromResult(new LoginResponse
        {
            IsSucceed = true,
            AccessToken = token.Value,
            Role = "Admin"
        });
    }
}