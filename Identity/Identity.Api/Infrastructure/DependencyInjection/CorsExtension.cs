namespace Identity.Api.Infrastructure.DependencyInjection;

public static class CorsExtension
{
    public static IServiceCollection AddDefaultCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                    .AllowCredentials();
                policy.AllowAnyHeader();
            });
        });

        return services;
    }
}