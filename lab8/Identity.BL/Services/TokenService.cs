using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.BL.Entity;
using Identity.BL.Helpers.Extensions;
using Identity.BL.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Identity.BL.Services;

public class TokenService : ITokenService
{
    private readonly IAuthenticationOption _authOption;

    public TokenService(IAuthenticationOption authOption)
    {
        _authOption = authOption;
    }

    public Token CreateAccessToken(string Email, string userId)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, Email),
            new Claim("id", userId)
        };

        //var claimsIdentity = new ClaimsIdentity(claims);
        // var jwtDescriptor = new SecurityTokenDescriptor
        // {
        //     Subject = claimsIdentity,
        //     Expires = DateTime.UtcNow.AddMinutes(15),
        //     SigningCredentials = new SigningCredentials(_authOption.Key.ConvertToSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256),
        //     Issuer = _authOption.Issuer,
        //     Audience = _authOption.Audience
        // };
        // создаем JWT-токен

        var jwt = new JwtSecurityToken(
                issuer: _authOption.Issuer,
                audience: _authOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(15)),
                signingCredentials: new SigningCredentials(_authOption.Key.ConvertToSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        // формируем ответ
        return new Token
        {
            Value = encodedJwt
        };
    }
}
