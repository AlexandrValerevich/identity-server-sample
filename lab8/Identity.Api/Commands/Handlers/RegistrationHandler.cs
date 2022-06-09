using Identity.Api.Abstraction;
using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responses;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Commands.Handlers;

public class RegistrationHandler : AuthHandlerAbstract<RegistrationRequest, RegistrationResponse>
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

    public override async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
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
}

