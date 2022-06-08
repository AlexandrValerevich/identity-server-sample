using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.BL.Entity;
using Identity.BL.Helpers;
using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Identity.BL.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;

    public RefreshTokenService(TokenValidationParameters tokenValidationParameters,
                               IRefreshTokenRepository refreshTokenRepository,
                               IUserRepository userRepository)
    {
        _tokenValidationParameters = tokenValidationParameters;
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
    }


    public async Task<IdentityUser> GetTokenOwner(string accessToken)
    {
        ClaimsPrincipal validatedToken = GetPrincipalFromToken(accessToken);
        if (validatedToken is null)
        {
            throw new NullReferenceException(nameof(validatedToken));
        }

        var userId = validatedToken.GetUserId();
        IdentityUser user = await _userRepository.ReadByIdAsync(userId);
        return user;
    }

    public async ValueTask<bool> IsValidTokens(string accessToken, string refreshToken)
    {
        ClaimsPrincipal validatedToken = GetPrincipalFromToken(accessToken);
        if (validatedToken is null)
        {
            return false;
        }

        if (IsValidatedTokenExpire(validatedToken))
        {
            return false;
        }

        var storedRefreshToken = await _refreshTokenRepository.Read(refreshToken);

        if (storedRefreshToken is null)
        {
            return false;
        }

        if (IsStoredRefreshTokenExpired(storedRefreshToken))
        {
            return false;
        }

        if (storedRefreshToken.Invalidated)
        {
            return false;
        }

        if (storedRefreshToken.IsUsed)
        {
            return false;
        }

        var jti = validatedToken.GetJti();

        if (!storedRefreshToken.JwtId.Equals(jti))
        {
            return false;
        }

        storedRefreshToken.IsUsed = false;
        await _refreshTokenRepository.Update(storedRefreshToken.Token, storedRefreshToken);

        return true;
    }

    public async Task<RefreshToken> CreateRefreshToken(IdentityUser user, string jwtId)
    {
        var refreshToken = new RefreshToken()
        {
            Token = Guid.NewGuid().ToString(),
            JwtId = jwtId,
            IsUsed = true,
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpireDate = DateTime.UtcNow.AddDays(5)
        };

        await _refreshTokenRepository.Create(refreshToken);
        return refreshToken;
    }

    private ClaimsPrincipal GetPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
            if (IsJwtWithValidSecurityAlghorithm(validatedToken))
            {
                return principal;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    private static bool IsJwtWithValidSecurityAlghorithm(SecurityToken validatedToken)
    {
        return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
            jwtSecurityToken.Header.Alg.EndsWith(SecurityAlgorithms.HmacSha256,
                                                 StringComparison.InvariantCultureIgnoreCase);
    }

    private static bool IsValidatedTokenExpire(ClaimsPrincipal validatedToken)
    {
        long expiryDateUnix = validatedToken.GetExpiryDateUnix();
        var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        .AddSeconds(expiryDateUnix);

        return DateTime.UtcNow > expiryDateTimeUtc;
    }

    private static bool IsStoredRefreshTokenExpired(RefreshToken token)
    {
        return DateTime.UtcNow > token.ExpireDate;
    }
}