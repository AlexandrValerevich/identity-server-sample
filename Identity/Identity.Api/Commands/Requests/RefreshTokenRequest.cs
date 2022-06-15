using Identity.Api.Commands.Responses;
using MediatR;

namespace Identity.Api.Commands.Requests;

public class RefreshTokenRequest : IRequest<RefreshTokenResponse>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}