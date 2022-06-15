using Identity.Api.Interfaces;

namespace Identity.Api.Commands.Responses;

public class RefreshTokenResponse : IAuthResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public bool IsSucceed { get; init; }
    public IEnumerable<string> Errors { get; set; }
}