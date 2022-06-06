using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using lab8.Contracts.Requests;
using lab8.Contracts.Responces;
using lab8.Infrastructure.Extensions;
using lab8.Infrastructure.Options;
using lab8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace lab8.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenthiticationController : ControllerBase
{
    private readonly AuthenticationOption _authOption;

    // условная бд с пользователями
    private readonly List<Person> people = new()
    {
        new Person("tom@gmail.com", "12345"),
        new Person("bob@gmail.com", "55555")
    };

    public AuthenthiticationController(IOptions<AuthenticationOption> options)
    {
        _authOption = options.Value;
    }

    [HttpGet("login")]
    public IActionResult Login([FromBody] LoginRequest loginData)
    {
        Person person = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
        // если пользователь не найден, отправляем статусный код 401
        if (person is null) return Unauthorized();

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
                issuer: _authOption.Issuer,
                audience: _authOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(_authOption.Key.ConvertToSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        // формируем ответ
        var response = new AuthorizedResponce(encodedJwt, person.Email);

        return Ok(response);
    }

    [Authorize]
    [HttpGet("data")]
    public IActionResult Data()
    {
        return Ok(new { message = "Hello World!" });
    }
}
