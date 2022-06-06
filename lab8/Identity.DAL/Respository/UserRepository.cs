using Identity.BL.Entity;
using Identity.BL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Identity.DAL.Respository;

public class UserRepository : IUserRepository
{
    private readonly DbUserContext _context;
    private DbSet<User> Users => _context.Users;

    public UserRepository(DbUserContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        EntityEntry<User> createdUser = await Users.AddAsync(user);
        await Save();
        return createdUser.Entity;
    }

    public async Task Delete(Guid id)
    {
        User deletedUser = await Read(id);
        Users.Remove(deletedUser);
        await Save();
    }

    public async Task<User> Read(Guid id)
    {
        return await Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
    }

    public async Task Update(User user)
    {
        User updatedUser = await Read(user.Id);
        updatedUser.Email = user.Email;
        updatedUser.Password = user.Password;
        Users.Update(updatedUser);

        await Save();
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
