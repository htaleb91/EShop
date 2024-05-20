using CukurovaLibrary.Data;
using CukurovaLibrary.Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShop.Models
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Seed Roles
                string[] roleNames = { "Adminstrator", "User" };
                foreach (var roleName in roleNames)
                {
                    var roleExist =await  roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                         await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                // Seed Default Admin User
                var adminUser = await userManager.FindByEmailAsync("admin@lib.cu.com");
                if (adminUser == null)
                {
                    adminUser = new User
                    {
                        UserName = "admin@lib.cu.com",
                        Email = "admin@lib.cu.com",
                        FirstName="Admin",
                        SureName="Admins"
                    };
                    await userManager.CreateAsync(adminUser, "Admin@123");

                    await userManager.AddToRoleAsync(adminUser, "Adminstrator");
                }

                // Seed Default test User
                var testUser = await userManager.FindByEmailAsync("testUser@lib.cu.com");
                if (testUser == null)
                {
                    testUser = new User
                    {
                        UserName = "testUser@lib.cu.com",
                        Email = "testUser@lib.cu.com",
                        FirstName = "User",
                        SureName = "Test"
                    };
                    await userManager.CreateAsync(testUser, "testUser@123");

                    await userManager.AddToRoleAsync(testUser, "User");
                }
            }
        }
    }

}
