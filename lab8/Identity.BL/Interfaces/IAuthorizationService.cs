using System.Threading.Tasks;
using Identity.BL.Entity;

namespace Identity.BL.Interfaces;

public interface IAuthorizationService
{
    Token CreateToken(string Email);
}
