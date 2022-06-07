namespace Identity.Api.Quries.Responces;

public class LoginResponse
{
    public string AccessToken { get; set; }
    public string Role { get; set; }
    public bool IsSucceed { get; init; }
}