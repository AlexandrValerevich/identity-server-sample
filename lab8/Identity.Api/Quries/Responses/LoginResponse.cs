namespace Identity.Api.Quries.Responces;

public class LoginResponse
{
    public string Token { get; set; }
    public bool IsSucceed { get; init; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}