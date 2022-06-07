using Identity.Api.Infrastructure.Options;
using Identity.BL.Helpers.Extensions;
using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Infrastructure.DependencyInjection;

public static class AuthentificationExtention
{
    public static IServiceCollection AddJwtAuthentification(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var AuthOptions = configuration
                .GetSection(AuthenticationOption.Authentication)
                .Get<AuthenticationOption>();

            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                // указывает, будет ли валидироваться издатель при валидации токена
                ValidateIssuer = true,
                // строка, представляющая издателя
                ValidIssuer = AuthOptions.Issuer,
                // будет ли валидироваться потребитель токена
                ValidateAudience = true,
                // установка потребителя токена
                ValidAudience = AuthOptions.Audience,
                // будет ли валидироваться время существования
                ValidateLifetime = true,
                // установка ключа безопасности
                IssuerSigningKey = AuthOptions.Key.ConvertToSymmetricSecurityKey(),
                // валидация ключа безопасности
                ValidateIssuerSigningKey = true,
            };
        });

        return services;
    }

    public static IServiceCollection AddAuthentificationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationOption>(
            configuration.GetSection(AuthenticationOption.Authentication)
        );

        services.AddScoped<IAuthenticationOption>(provider =>
        {
            var options = provider.GetService<IOptions<AuthenticationOption>>();
            return options.Value;
        });

        return services;
    }
}