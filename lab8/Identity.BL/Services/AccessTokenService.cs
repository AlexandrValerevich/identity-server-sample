using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.BL.Entity;
using Identity.BL.Helpers;
using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Identity.BL.Services;

public class AccessTokenService : IAccessTokenService
{
    private readonly IAuthenticationOption _authOption;

    public AccessTokenService(IAuthenticationOption authOption)
    {
        _authOption = authOption;
    }

    public AccessToken CreateTokens(IdentityUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("id", user.Id)
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

        var jwtSecurityToken = new JwtSecurityToken(
                issuer: _authOption.Issuer,
                audience: _authOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(_authOption.TokenLifeTime),
                signingCredentials: new SigningCredentials(_authOption.Key.ConvertToSymmetricSecurityKey(),
                                                           SecurityAlgorithms.HmacSha256));

        string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        // формируем ответ
        return new AccessToken
        {
            Value = accessToken,
            JwtId = jwtSecurityToken.Id
        };
    }
}
