using Microsoft.IdentityModel.Tokens;

namespace lab8.Infrastructure.Options;

public class AuthenticationOption
{
    public const string Authentication = "Authentication";
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }

}
