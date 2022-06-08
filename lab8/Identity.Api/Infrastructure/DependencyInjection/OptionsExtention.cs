using Identity.Api.Infrastructure.Options;
using Identity.BL.Interfaces;
using Microsoft.Extensions.Options;

namespace Identity.Api.Infrastructure.DependencyInjection;

public static class OptionsExtention
{
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