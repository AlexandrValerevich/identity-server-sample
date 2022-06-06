using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace lab8.Infrastructure.Extensions;

public static class StringExtensions
{
    public static SymmetricSecurityKey ConvertToSymmetricSecurityKey(this string value)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(value));
    }
}
