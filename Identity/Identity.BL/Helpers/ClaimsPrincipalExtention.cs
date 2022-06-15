using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.BL.Helpers;

public static class ClaimsPrincipalExtention
{
    public static long GetExpiryDateUnix(this ClaimsPrincipal principal)
    {
        return long.Parse(principal.Claims.Single(claim => claim.Type.Equals(JwtRegisteredClaimNames.Exp)).Value);
    }

    public static string GetJti(this ClaimsPrincipal principal)
    {
        return principal.Claims.Single(claim => claim.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;
    }

    public static string GetUserId(this ClaimsPrincipal principal)
    {
        return principal.Claims.Single(claim => claim.Type.Equals("id")).Value;
    }

    public static string GetEmail(this ClaimsPrincipal principal)
    {
        return principal.Claims.Single(claim => claim.Type.Equals(JwtRegisteredClaimNames.Email)).Value;
    }
}