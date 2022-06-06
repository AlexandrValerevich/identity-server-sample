using System;
using System.Collections.Generic;
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

    public Token CreateToken(string Email)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, Email) };
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
                issuer: _authOption.Issuer,
                audience: _authOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(_authOption.Key.ConvertToSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        // формируем ответ
        return new Token
        {
            Value = encodedJwt
        };
    }
}
