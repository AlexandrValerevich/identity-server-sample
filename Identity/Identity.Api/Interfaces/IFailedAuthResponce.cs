namespace Identity.Api.Interfaces;

public interface IFailedAuthResponse
{
    IEnumerable<string> Errors { get; set; }
}