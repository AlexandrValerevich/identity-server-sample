using Identity.DAL;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Infrastructure.DependencyInjection;

public static class DatabaseExtensions
{
    public static IServiceCollection AddUserDbContext(this IServiceCollection services)
    {
        services.AddDbContext<DbUserContext>(options =>
        {
            options.UseSqlite("Data Source=user.db");
        });
        
        return services;
    }
}
