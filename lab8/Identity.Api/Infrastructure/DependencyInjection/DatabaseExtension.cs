using Identity.BL.Interfaces;
using Identity.DAL;
using Identity.DAL.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Api.Infrastructure.DependencyInjection;

public static class DatabaseExtensions
{
    public static IServiceCollection AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbIdentityContext>(options =>
        {
            //options.UseSqlite("Data Source=user.db");
            var connectionStriong = configuration.GetConnectionString("IdentityUser");
            options.UseNpgsql(connectionStriong);
        });


        services.AddIdentityCore<IdentityUser>()
              .AddEntityFrameworkStores<DbIdentityContext>();

        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
