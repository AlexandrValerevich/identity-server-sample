using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.DAL.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser> ReadByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
}