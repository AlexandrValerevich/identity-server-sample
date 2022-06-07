namespace Identity.Api.Commands.Responces;

public class RegistrationResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string Role { get; set; }
    public bool IsSucceed { get; init; }
}