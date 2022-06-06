using System;
using System.Threading.Tasks;
using Identity.BL.Entity;

namespace Identity.BL.Interfaces;

public interface IUserService
{
    Task<User> Create(User user);
    Task<User> Read(Guid id);
    Task Update(User user);
    Task Delete(Guid id);
}
