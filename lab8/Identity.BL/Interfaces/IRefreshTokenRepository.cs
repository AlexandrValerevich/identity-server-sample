using Identity.BL.Entity;

namespace Identity.BL.Interfaces;

public interface IRefreshTokenRepository
{
    Task Create(RefreshToken token);
    Task<RefreshToken> Read(string token);
    Task Update(string tokenId, RefreshToken token);
}