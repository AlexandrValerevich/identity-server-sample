using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Identity.BL.Entity;

namespace Identity.DAL;

public class DbIdentityContext : IdentityDbContext<IdentityUser>
{
    public DbIdentityContext(DbContextOptions<DbIdentityContext> options) : base(options)
    {
    }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DbIdentityContext).Assembly);
    }
}
