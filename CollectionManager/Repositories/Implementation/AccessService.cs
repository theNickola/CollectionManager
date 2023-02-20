using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace CollectionManager.Repositories.Implementation
{
    public class AccessService : IAccessService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccessService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> hasAdminRole(User user)
        {
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList().Any(role => role == RolesInit.GetNameAdminRole());
        }
        public async Task<bool> IsExistUser(string userLogin)
        {
            User user = await _userManager.FindByEmailAsync(userLogin);
            if (user != null)
                return true;
            await _signInManager.SignOutAsync();
            return false;
        }
        public async Task<bool> IsActiveUser(string userLogin)
        {
            User user = await _userManager.FindByEmailAsync(userLogin);
            if (user.Active)
                return true;
            await _signInManager.SignOutAsync();
            return false;
        }
        public async Task<bool> IsInAdminRole(string userLogin)
        {
            User user = await _userManager.FindByEmailAsync(userLogin);
            if (hasAdminRole(user).Result)
                return true;
            await _signInManager.RefreshSignInAsync(user);
            return false;
        }
        public async Task<bool> IsUserRule(string userLogin)
        {
            if (IsExistUser(userLogin).Result)
                if (IsInAdminRole(userLogin).Result && IsActiveUser(userLogin).Result)
                    return true;
            return false;
        }
    }
}
