using Identity.BL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Identity.DAL;

public class DbUserContext : DbContext
{
    public DbUserContext(DbContextOptions<DbUserContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
}
