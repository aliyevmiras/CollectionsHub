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
                RoleManager<IdentityRole<Guid>> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                if(!context.Roles.Any())
                {
                    var result = await roleManager.CreateAsync(new IdentityRole<Guid>("Administrator"));
                }


                if (!context.Users.Any())
                {
                    User addUser = new User { Email = "admin@gmail.com", UserName = "admin" };
                    string hashedPassword = userManager.PasswordHasher.HashPassword(addUser, "admin");
                    addUser.PasswordHash = hashedPassword;
                    var result = await userManager.CreateAsync(addUser);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(addUser, "Administrator");
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Collections.Any())
                {
                    Category addCategory = new Category { Title = "TestCategory" };
                    context.Categories.Add(addCategory);

                    User addUser = new User { Email = "collectionOwner@gmail.com", UserName = "collectionOwner@gmail.com" };
                    string hashedPassword = userManager.PasswordHasher.HashPassword(addUser, "collectionOwner@gmail.com");
                    addUser.PasswordHash = hashedPassword;
                    var result = await userManager.CreateAsync(addUser);

                    context.Collections.Add(new Collection { Author = addUser, Name = "New collection", Description = "New description", Category = addCategory});

                    await context.SaveChangesAsync();
                }
            }


        }
    }
}
