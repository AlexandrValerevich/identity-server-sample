using Identity.BL.Entity;
using Microsoft.AspNetCore.Identity;

namespace Identity.BL.Interfaces;

public interface IPasswordService
{
    string HashPassword(string password);
    bool Verify(string password, string hashedPassword);
    string ValidateAndReplacePassword(string currentPassword, string currentHashe, string newPassword);
}
