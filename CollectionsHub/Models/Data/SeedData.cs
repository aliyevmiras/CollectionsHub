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
                    userManager.PasswordHasher.HashPassword(addUser, "_l0-S@yY1$EMB{5237XfiJyP6z6wm<u4RD->5");
                    var result = await userManager.CreateAsync(addUser);
                    if(!result.Succeeded)
                    {
                        foreach(var i in result.Errors)
                        {
                            Debug.WriteLine("Error:");
                            Debug.WriteLine(i.Code);
                            Debug.WriteLine(i.Description);
                        }
                        throw new ArgumentException("Password is not valid?");
                    }
                    await context.SaveChangesAsync();

                }
            }


        }
    }
}
