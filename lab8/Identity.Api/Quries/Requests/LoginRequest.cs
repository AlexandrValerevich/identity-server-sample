using Identity.Api.Quries.Responces;
using MediatR;

namespace Identity.Api.Quries.Requests;

public class LoginRequest : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
