using EducacionVitual.ViewsModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EducacionVitual.Helpers
{
    public interface IUserHelper
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        
        Task<IdentityResult> AddUserAsync(ApplicationUser user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(ApplicationUser user, string roleName);

        Task<bool> IsUserInRoleAsync(ApplicationUser user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        Task<ApplicationUser> AddUserAsync(AddUserViewModel model, string path);
    }
}
