using Microsoft.OpenApi.Models;

namespace Identity.Api.Infrastructure.DependencyInjection;

public static class SwaggerExtention
{
    public static IServiceCollection AddConfiguredSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Auth server",
                Version = "v1"
            });

            var openApiSecurityScheme = new OpenApiSecurityScheme
            {
                Description = "JWT Authentification header uisng the bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            };

            options.AddSecurityDefinition("Baerer", openApiSecurityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {openApiSecurityScheme, Array.Empty<string>()}
            });
        });

        return services;
    }
}
