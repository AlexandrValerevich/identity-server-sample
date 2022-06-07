using Identity.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Api.Infrastructure.DependencyInjection;

public static class DatabaseExtensions
{
    public static IServiceCollection AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbUserContext>(options =>
        {
            //options.UseSqlite("Data Source=user.db");
            var connectionStriong = configuration.GetConnectionString("IdentityUser");
            options.UseNpgsql(connectionStriong);
        });

        services.AddIdentityCore<IdentityUser>()
              .AddEntityFrameworkStores<DbUserContext>();

        return services;
    }
}
