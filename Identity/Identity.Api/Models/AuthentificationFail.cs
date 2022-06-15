namespace Identity.Api.Models;


public class AuthentificationFail
{
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
