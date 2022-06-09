using Identity.Api.Interfaces;

namespace Identity.Api.Quries.Responces;

public class LoginResponse : IAuthResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public bool IsSucceed { get; init; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}