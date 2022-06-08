using Identity.Api.Quries.Requests;
using Identity.Api.Quries.Responces;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Quries.Handlers;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<IdentityUser> _userManager;

    public LoginHandler(ITokenService tokenService,
                        UserManager<IdentityUser> userManager)
    {
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
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

        Token token = _tokenService.CreateAccessToken(user.Email, user.Id);

        return Ok(token.Value);
    }

    private static LoginResponse Ok(string token)
    {
        return new LoginResponse
        {
            Token = token,
            IsSucceed = true
        };
    }

    private static LoginResponse Bad(IEnumerable<string> errors)
    {
        return new LoginResponse
        {
            Errors = errors,
            IsSucceed = false
        };
    }
}