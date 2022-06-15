using Microsoft.AspNetCore.Identity;

namespace Identity.BL.Entity;

public class RefreshToken
{
    public string Token { get; set; }
    public string JwtId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public bool IsUsed { get; set; }
    public bool Invalidated { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}