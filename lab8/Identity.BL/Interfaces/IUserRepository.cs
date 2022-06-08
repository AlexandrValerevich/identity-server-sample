using Microsoft.AspNetCore.Identity;

namespace Identity.BL.Interfaces;

public interface IUserRepository
{
    Task<IdentityUser> ReadByIdAsync(string userId);
}