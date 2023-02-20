using CollectionManager.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace CollectionManager.Data
{
    public class RolesInit
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<User>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            WebApplicationBuilder? builder = WebApplication.CreateBuilder();
            await CreateRoles(roleManager, builder);
            await CreateAdmin(userManager, builder);
        }
        static async Task CreateRoles(RoleManager<IdentityRole> roleManager, WebApplicationBuilder builder)
        {
            foreach (var role in builder.Configuration.GetSection("RolesApplication").GetChildren().ToArray())
            {
                var roleInDb = await roleManager.FindByNameAsync(role.Value);
                if (roleInDb == null)
                    await roleManager.CreateAsync(new IdentityRole(role.Value));
            }
        }
        static async Task CreateAdmin(UserManager<User> userManager, WebApplicationBuilder builder)
        {
            User user = GetUserAdmin(builder);
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, builder.Configuration.GetSection("AdminInformation")["FirsrPassword"]);
                await userManager.AddToRolesAsync(user, new List<string> { GetNameUserRole(), GetNameAdminRole() });
            }
        }
        static User GetUserAdmin(WebApplicationBuilder builder)
        {
            return new User
            {
                UserName = builder.Configuration.GetSection("AdminInformation")["Email"],
                Email = builder.Configuration.GetSection("AdminInformation")["Email"],
                Name = builder.Configuration.GetSection("AdminInformation")["Name"],
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
        }
        public static string GetNameAdminRole()
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder();
            return builder.Configuration.GetSection("RolesApplication")["AdminRole"];
        }
        public static string GetNameUserRole()
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder();
            return builder.Configuration.GetSection("RolesApplication")["UserRole"];
        }
    }
}
