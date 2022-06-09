using Identity.Api.Abstraction;
using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responses;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Commands.Handlers;

public class RefreshTokenHandler : AuthHandlerAbstract<RefreshTokenRequest, RefreshTokenResponse>
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;

    public RefreshTokenHandler(IAccessTokenService tokenService,
                               IRefreshTokenService refreshTokenService)
    {
        _accessTokenService = tokenService;
        _refreshTokenService = refreshTokenService;
    }

    public override async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        bool isTokenValid = await _refreshTokenService.IsValidTokens(request.AccessToken, request.RefreshToken);

        if (!isTokenValid)
        {
            return Bad(new[] { "Invalid tokens" });
        }

        IdentityUser tokenOwner = await _refreshTokenService.GetTokenOwner(request.AccessToken);
        AccessToken accessToken = _accessTokenService.CreateTokens(tokenOwner);
        RefreshToken refreshToken = await _refreshTokenService.CreateRefreshToken(tokenOwner, accessToken.JwtId);

        return Ok(accessToken.Value, refreshToken.Token);
    }

}