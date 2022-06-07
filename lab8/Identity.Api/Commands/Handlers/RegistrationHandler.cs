using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responces;
using Identity.BL.Entity;
using Identity.BL.Interfaces;
using MediatR;

namespace Identity.Api.Commands.Handlers;

public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IUserService _userService;

    public RegistrationHandler(ITokenService tokenService,
                               IPasswordService passwordService,
                               IUserService userService)
    {
        _tokenService = tokenService;
        _passwordService = passwordService;
        _userService = userService;
    }

    public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var hashedPassword = _passwordService.HashPassword(request.Password);
        var createdUser = await _userService.Create(new User{
            Email = request.Email,
            Password = hashedPassword,
        });
        var accessToken = _tokenService.CreateAccessToken(createdUser.Email);

        return new RegistrationResponse
        {
            AccessToken = accessToken.Value,
            IsSucceed = true,
            Role = "User"
        };
    }
}