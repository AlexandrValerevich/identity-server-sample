using Identity.BL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Identity.BL.Entity;
using System.Security.Cryptography;

namespace Identity.BL.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(User user, string password)
    {
        if (password is null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        byte[] salt;
        byte[] buffer;

        using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
        {
            salt = bytes.Salt;
            buffer = bytes.GetBytes(0x20);
        }

        byte[] dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer, 0, dst, 0x11, 0x20);

        return Convert.ToBase64String(dst);
    }

    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string password)
    {
        byte[] buffer4;

        if (hashedPassword is null)
        {
            return PasswordVerificationResult.Failed;
        }

        if (password is null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        byte[] src = Convert.FromBase64String(hashedPassword);
        if (IsValidHashLength(src))
        {
            return PasswordVerificationResult.Failed;
        }

        byte[] dst = new byte[0x10];
        Buffer.BlockCopy(src, 1, dst, 0, 0x10);
        byte[] buffer3 = new byte[0x20];
        Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);

        using (var bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
        {
            buffer4 = bytes.GetBytes(0x20);
        }

        return ByteArraysEqual(buffer4, buffer3) 
            ? PasswordVerificationResult.Success 
            : PasswordVerificationResult.Failed;
    }

    private static bool IsValidHashLength(byte[] src)
    {
        return (src.Length != 0x31) || (src[0] != 0);
    }

    private static bool ByteArraysEqual(byte[] buffer4, byte[] buffer3)
    {
        return buffer3.Equals(buffer4);
    }
}
