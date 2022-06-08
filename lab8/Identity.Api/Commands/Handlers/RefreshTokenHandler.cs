using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responses;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Commands.Handlers;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResponce>
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;

    public RefreshTokenHandler(IAccessTokenService tokenService,
                               IRefreshTokenService refreshTokenService)
    {
        _accessTokenService = tokenService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<RefreshTokenResponce> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
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

    private static RefreshTokenResponce Ok(string accessToken, string refreshToken)
    {
        return new RefreshTokenResponce
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            IsSucceed = true
        };
    }

    private static RefreshTokenResponce Bad(IEnumerable<string> errors)
    {
        return new RefreshTokenResponce
        {
            Errors = errors,
            IsSucceed = false
        };
    }

}