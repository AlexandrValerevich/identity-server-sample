using Identity.BL.Interfaces;

namespace Identity.Api.Infrastructure.Options;

public class AuthenticationOption : IAuthenticationOption
{
    public const string Authentication = "Authentication";
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public TimeSpan TokenLifeTime { get; set; }
}
