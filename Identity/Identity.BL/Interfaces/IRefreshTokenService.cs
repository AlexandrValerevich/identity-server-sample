using Identity.BL.Entity;
using Microsoft.AspNetCore.Identity;

namespace Identity.BL.Interfaces;

public interface IRefreshTokenService
{
    ValueTask<bool> IsValidTokens(string accessToken, string refreshToken);
    Task<IdentityUser> GetTokenOwner(string accessToken);
    Task<RefreshToken> CreateRefreshToken(IdentityUser user, string jwtId);
}