using System;
using System.Threading.Tasks;
using Identity.BL.Entity;
using Identity.BL.Interfaces;

namespace Identity.BL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Create(User user)
    {
        return await _repository.Create(user);
    }

    public async Task<User> Read(Guid id)
    {
        return await _repository.Read(id);
    }

    public async Task Update(User user)
    {
        await _repository.Update(user);
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
    }

}
