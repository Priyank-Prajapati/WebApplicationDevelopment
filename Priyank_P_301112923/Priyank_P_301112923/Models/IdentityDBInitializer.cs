using Priyank_P_301112923.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class IdentityDBInitializer
    {
        public static async Task Initialize(AppIdentityDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;   // DB has been seeded  
            }
            await CreateDefaultUserAndRole(userManager, roleManager);
            // add any initial data to the application
            context.SaveChanges();
        }
        private static async Task CreateDefaultUserAndRole(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string roleAdmin = "Admin";
            string roleUser = "User";
            // create the two default role: User, Admin
            await CreateDefaultRole(roleManager, roleAdmin);
            await CreateDefaultRole(roleManager, roleUser);
            // create the default admin user account
            var user = await CreateDefaultUser(userManager, "admin", "Admin123!");
            await AddDefaultRoleToDefaultUser(userManager, roleAdmin, user);
            // create app user account for testing
            user = await CreateDefaultUser(userManager, "tAccount", "testUser1!");
            await AddDefaultRoleToDefaultUser(userManager, roleUser, user);
            user = await CreateDefaultUser(userManager, "brian", "testUser1!");
            await AddDefaultRoleToDefaultUser(userManager, roleUser, user);
        }

        private static async Task CreateDefaultRole(RoleManager<IdentityRole> roleManager, string role)
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }

        private static async Task<AppUser> CreateDefaultUser(UserManager<AppUser> userManager, String username, String password)
        {
            var user = new AppUser { UserName = username };

            await userManager.CreateAsync(user, password);

            var createdUser = await userManager.FindByNameAsync(username);
            return createdUser;
        }

        private static async Task AddDefaultRoleToDefaultUser(UserManager<AppUser> userManager, string role, AppUser user)
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}
