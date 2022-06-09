namespace Identity.Api.Interfaces;

public interface ISuccessAuthResponse
{
    string AccessToken { get; set; }
    string RefreshToken { get; set; }
}