using Identity.BL.Entity;
using Microsoft.AspNetCore.Identity;

namespace Identity.BL.Interfaces;

public interface IAccessTokenService
{
    AccessToken CreateTokens(IdentityUser user);
    // Task<AccessToken> RefreshTokensAsync(string accessToken, string refreshToken, IdentityUser user);
}
