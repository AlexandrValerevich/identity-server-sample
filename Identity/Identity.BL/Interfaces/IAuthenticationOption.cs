namespace Identity.BL.Interfaces;

public interface IAuthenticationOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public TimeSpan TokenLifeTime { get; set; }
}
