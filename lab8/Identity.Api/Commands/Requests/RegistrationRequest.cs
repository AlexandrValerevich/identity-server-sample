using Identity.Api.Commands.Responces;
using MediatR;

namespace Identity.Api.Commands.Requests;

public class RegistrationRequest : IRequest<RegistrationResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
