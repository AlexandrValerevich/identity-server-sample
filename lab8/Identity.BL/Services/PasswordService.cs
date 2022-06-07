using Identity.BL.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace Identity.BL.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool Verify(string password, string hashPassword)
    {
        return BC.Verify(password, hashPassword);
    }

    public string ValidateAndReplacePassword(string currentPassword,
                                             string currentHashe,
                                             string newPassword)
    {
        return BC.ValidateAndReplacePassword(currentPassword, currentHashe, newPassword);
    }
}
