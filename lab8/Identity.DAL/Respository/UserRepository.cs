// using System.Security.Claims;
// using Identity.BL.Entity;
// using Identity.BL.Interfaces;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;

// namespace Identity.DAL.Respository;

// public class UserRepository : IUserRepository
// {
//     private readonly UserManager<IdentityUser> _userManager;

//     public UserRepository(UserManager<IdentityUser> userManager)
//     {
//         _userManager = userManager;
//     }

//     public async Task<User> Read(Guid id)
//     {
//         _userManager.GetUserAsync(new ClaimsPrincipal
//         {
//             Identity = 
//         });
//         return await Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
//     }

//     public async Task<bool> Create(User user)
//     {
//         var identityUser = new IdentityUser
//         {
//             Email = user.Email,
//         };
//         IdentityResult identityResult = await _userManager.CreateAsync(identityUser, user.Password);

//         return identityResult.Succeeded;
//     }

//     public async Task Delete(Guid id)
//     {
//         await _userManager.DeleteAsync();
//         User deletedUser = await Read(id);
//         Users.Remove(deletedUser);
//         await Save();
//     }

//     public async Task Update(User user)
//     {
//         User updatedUser = await Read(user.Id);
//         updatedUser.Email = user.Email;
//         updatedUser.Password = user.Password;
//         Users.Update(updatedUser);

//         await Save();
//     }

//     private async Task Save()
//     {
//         await _context.SaveChangesAsync();
//     }
// }
