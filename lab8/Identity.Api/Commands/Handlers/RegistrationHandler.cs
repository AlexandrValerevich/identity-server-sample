using Identity.Api.Commands.Requests;
using Identity.Api.Commands.Responces;
using Identity.BL.Interfaces;
using MediatR;

namespace Identity.Api.Commands.Handlers;

public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
{
    private readonly ITokenService _tokenService;

    public RegistrationHandler(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}