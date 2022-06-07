using Identity.BL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Identity.DAL;

public class DbUserContext : IdentityDbContext<IdentityUser>
{
    public DbUserContext(DbContextOptions<DbUserContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
