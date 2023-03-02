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

        private async Task<bool> hasAdminRole(User user)
        {
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList().Any(role => role == RolesInit.GetNameAdminRole());
        }
        private async Task<bool> IsExistUser(string identityName)
        {
            User user = await _userManager.FindByEmailAsync(identityName);
            if (user != null)
                return true;
            await _signInManager.SignOutAsync();
            return false;
        }
        private async Task<bool> IsActiveUser(string identityName)
        {
            User user = await _userManager.FindByEmailAsync(identityName);
            if (user.Active)
                return true;
            await _signInManager.SignOutAsync();
            return false;
        }
        private async Task<bool> IsInAdminRole(string identityName)
        {
            User user = await _userManager.FindByEmailAsync(identityName);
            if (hasAdminRole(user).Result)
                return true;
            await _signInManager.RefreshSignInAsync(user);
            return false;
        }
        public async Task<bool> IsUserRule(string identityName)
        {
            if (IsExistUser(identityName).Result)
                if (IsActiveUser(identityName).Result)
                    return true;
            return false;
        }
        public async Task<bool> IsAdminRule(string identityName)
        {
            if (IsExistUser(identityName).Result)
                if (IsActiveUser(identityName).Result)
                    if (IsInAdminRole(identityName).Result)
                        return true;
            return false;
        }
    }
}
