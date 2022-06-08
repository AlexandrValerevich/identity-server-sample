namespace Identity.Api.Commands.Responses;

public class RefreshTokenResponce
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public bool IsSucceed { get; set; }
    public IEnumerable<string> Errors { get; set; }
}