using Identity.Api.Abstraction;
using Identity.Api.Quries.Requests;
using Identity.Api.Quries.Responces;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Quries.Handlers;

public class LoginHandler : AuthHandlerAbstract<LoginRequest, LoginResponse>
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly UserManager<IdentityUser> _userManager;

    public LoginHandler(IAccessTokenService tokenService,
                        UserManager<IdentityUser> userManager,
                        IRefreshTokenService refreshTokenService)
    {
        _accessTokenService = tokenService;
        _userManager = userManager;
        _refreshTokenService = refreshTokenService;
    }

    public override async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            var errors = new[] { "User does not exist." };
            return Bad(errors);
        }

        bool isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isValidPassword)
        {
            var errors = new[] { "Invalid password" };
            return Bad(errors);
        }

        AccessToken accessToken = _accessTokenService.CreateTokens(user);
        RefreshToken refreshToken = await _refreshTokenService.CreateRefreshToken(user, accessToken.JwtId);

        return Ok(accessToken.Value, refreshToken.Token);
    }
}