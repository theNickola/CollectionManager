using CollectionManager.Data;
using CollectionManager.Models.Admin;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Data;

namespace CollectionManager.Repositories.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AdminService(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public bool AddAdminRole(string id)
        {
            try
            {
                AddAdminRoleToUser(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveAdminRole(string id)
        {
            try
            {
                RemoveAdminRoleFromUser(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Block(string id)
        {
            try
            {
                var user = FindById(id);
                if (user == null)
                    return false;
                SetUserActivity(user, false);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Unblock(string id)
        {
            try
            {
                var user = FindById(id);
                if (user == null)
                    return false;
                SetUserActivity(user, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var user = FindById(id);
                if (user == null)
                    return false;
                _context.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public User? FindById(string id)
        {
            return _context.Users.Find(id);
        }
        public IEnumerable<UserInfo> GetAll()
        {
            List<UserInfo> userList = new();
            var users = _context.Users.ToList();
            foreach (var user in users)
                userList.Add(new UserInfo(user) { Roles = GetUserRoles(user.Id.ToString()).Result.ToString() });
            return userList;
        }
        public async Task<string> GetUserRoles(string id)
        {
            User? user = FindById(id);
            IList<string> rolesName = await _userManager.GetRolesAsync(user);
            return string.Join(", ", rolesName.ToArray());
        }
        private void AddAdminRoleToUser(string id)
        {
            IdentityUserRole<string> identityUserRole = new()
            {
                UserId = id,
                RoleId = _context.Roles.First(role => role.Name == RolesInit.GetNameAdminRole()).Id.ToString()
            };
            _context.UserRoles.Add(identityUserRole);
            _context.SaveChanges();
        }
        private void RemoveAdminRoleFromUser(string id)
        {
            IdentityUserRole<string> identityUserRole = new()
            {
                UserId = id,
                RoleId = _context.Roles.First(role => role.Name == RolesInit.GetNameAdminRole()).Id.ToString()
            };
            _context.UserRoles.Remove(identityUserRole);
            _context.SaveChanges();
        }
        private void SetUserActivity(User user, bool activeState)
        {
            user.Active = activeState;
            _context.Users.Update(user);
            _context.SaveChanges();
        }


    }
}
