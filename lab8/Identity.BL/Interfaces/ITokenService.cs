using System.Threading.Tasks;
using Identity.BL.Entity;

namespace Identity.BL.Interfaces;

public interface ITokenService
{
    Token CreateToken(string Email);
}