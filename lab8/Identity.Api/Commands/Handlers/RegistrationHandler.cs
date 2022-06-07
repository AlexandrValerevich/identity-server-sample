using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responces;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Commands.Handlers;

public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<IdentityUser> _userManager;

    public RegistrationHandler(ITokenService tokenService,
                               UserManager<IdentityUser> userManager)
    {
        _tokenService = tokenService;
        _userManager = userManager;
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

        Token token = _tokenService.CreateAccessToken(request.Email, newUser.Id);

        return Ok(token.Value);
    }

    private static RegistrationResponse Ok(string token)
    {
        return new RegistrationResponse
        {
            Token = token,
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

