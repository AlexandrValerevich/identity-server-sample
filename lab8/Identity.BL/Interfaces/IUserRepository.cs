using Identity.BL.Entity;

namespace Identity.BL.Interfaces;

public interface IUserRepository
{
    Task<bool> Create(User user);
    Task<User> Read(Guid id);
    Task Update(User user);
    Task Delete(Guid id);
}
