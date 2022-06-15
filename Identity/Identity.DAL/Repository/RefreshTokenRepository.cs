using Identity.BL.Entity;
using Identity.BL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.DAL.Repository;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly DbIdentityContext _context;
    private DbSet<RefreshToken> RefreshTokens => _context.RefreshTokens;

    public RefreshTokenRepository(DbIdentityContext context)
    {
        _context = context;
    }

    public async Task Create(RefreshToken token)
    {
        await RefreshTokens.AddAsync(token);
        await Save();
    }

    public async Task<RefreshToken> Read(string token)
    {
        return await RefreshTokens.SingleOrDefaultAsync(rt => rt.Token.Equals(token));
    }

    public async Task Update(string tokenId, RefreshToken token)
    {
        var updatedToken = await Read(tokenId);

        updatedToken.CreationDate = token.CreationDate;
        updatedToken.ExpireDate = token.ExpireDate;
        updatedToken.Invalidated = token.Invalidated;
        updatedToken.IsUsed = token.IsUsed;
        updatedToken.JwtId = token.JwtId;
        updatedToken.UserId = token.UserId;

        RefreshTokens.Update(updatedToken);
        await Save();
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}