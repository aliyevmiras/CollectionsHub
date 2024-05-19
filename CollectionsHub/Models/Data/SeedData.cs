using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace CollectionsHub.Models.Data
{
    public static class SeedData
    {
        public async static void EnsurePopulated(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                UserManager<User> userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                if (!context.Users.Any())
                {
                    User addUser = new User { Email = "nonexisting@gmail.com", UserName = "nonexistingusername" };
                    string hashedPassword = userManager.PasswordHasher.HashPassword(addUser, "deafultPassword");
                    addUser.PasswordHash = hashedPassword;
                    var result = await userManager.CreateAsync(addUser);
                    if (result.Succeeded)
                    {
                        // add role?
                    }
                    await context.SaveChangesAsync();

                }
            }


        }
    }
}
