using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responces;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Commands.Handlers;

public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
{
    private readonly IAccessTokenService _tokenService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IRefreshTokenService _refreshTokenService;

    public RegistrationHandler(IAccessTokenService tokenService,
                               UserManager<IdentityUser> userManager,
                               IRefreshTokenService refreshTokenService)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
    {
        IdentityUser existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser is not null)
        {
            var errors = new[] { "User with this email alredy exist." };
            return Bad(errors);
        }

        var newUser = new IdentityUser
        {
            Email = request.Email,
            UserName = request.Email
        };
        IdentityResult identityResult = await _userManager.CreateAsync(newUser, request.Password);

        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors.Select(err => err.Description);
            return Bad(errors);
        }

        AccessToken accessToken = _tokenService.CreateTokens(newUser);
        RefreshToken refreshToken = await _refreshTokenService.CreateRefreshToken(newUser, accessToken.JwtId);

        return Ok(accessToken.Value, refreshToken.Token);
    }

    private static RegistrationResponse Ok(string accessToken, string refreshToken)
    {
        return new RegistrationResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            IsSucceed = true
        };
    }

    private static RegistrationResponse Bad(IEnumerable<string> errors)
    {
        return new RegistrationResponse
        {
            Errors = errors,
            IsSucceed = false
        };
    }
}

