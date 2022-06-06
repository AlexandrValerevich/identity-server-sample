using Identity.BL.Entity;
using Microsoft.AspNetCore.Identity;

namespace Identity.BL.Interfaces;

public interface IPasswordService : IPasswordHasher<User>
{
}
