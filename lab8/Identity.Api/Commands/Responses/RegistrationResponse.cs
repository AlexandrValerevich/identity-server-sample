namespace Identity.Api.Commands.Responces;

public class RegistrationResponse
{
    public string Token { get; set; }
    public bool IsSucceed { get; init; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}