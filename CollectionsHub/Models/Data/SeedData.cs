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

                    var addCollection = new Collection { Author = addUser, Name = "New collection1", Description = "New description", Category = addCategory };
                    context.Collections.Add(addCollection);

                    context.Items.Add(new Item { Name = "TestItem1", Collection = addCollection});
                    context.Items.Add(new Item { Name = "TestItem2", Collection = addCollection });
                    context.Items.Add(new Item { Name = "TestItem3", Collection = addCollection });
                    context.Items.Add(new Item { Name = "TestItem4", Collection = addCollection });
                    context.Items.Add(new Item { Name = "TestItem5", Collection = addCollection });
                    context.Items.Add(new Item { Name = "TestItem6", Collection = addCollection });
                    context.Items.Add(new Item { Name = "TestItem7", Collection = addCollection });


                    var secondCollection = new Collection { Author = addUser, Name = "New collection2", Description = "New description", Category = addCategory };
                    context.Collections.Add(addCollection);
                    context.Items.Add(new Item { Name = "TestItem1", Collection = secondCollection });

                    var thirdCollection = new Collection { Author = addUser, Name = "New collection3", Description = "New description", Category = addCategory };
                    context.Collections.Add(thirdCollection);
                    context.Items.Add(new Item { Name = "TestItem1", Collection = thirdCollection });
                    context.Items.Add(new Item { Name = "TestItem2", Collection = thirdCollection });
                    context.Items.Add(new Item { Name = "TestItem3", Collection = thirdCollection });

                    var fourthCollection = new Collection { Author = addUser, Name = "New collection4", Description = "New description", Category = addCategory };
                    context.Collections.Add(fourthCollection);
                    context.Items.Add(new Item { Name = "TestItem1", Collection = fourthCollection });
                    context.Items.Add(new Item { Name = "TestItem2", Collection = fourthCollection });


                    var fifthCollection = new Collection { Author = addUser, Name = "New collection5", Description = "New description", Category = addCategory };
                    context.Collections.Add(fifthCollection);
                    context.Items.Add(new Item { Name = "TestItem1", Collection = fifthCollection });
                    context.Items.Add(new Item { Name = "TestItem2", Collection = fifthCollection });

                    var sixthCollection = new Collection { Author = addUser, Name = "New collection6", Description = "New description", Category = addCategory };
                    context.Collections.Add(sixthCollection);
                    context.Items.Add(new Item { Name = "TestItem1", Collection = sixthCollection });
                    context.Items.Add(new Item { Name = "TestItem2", Collection = sixthCollection });


                    context.Collections.Add(addCollection);


                    await context.SaveChangesAsync();
                }
            }


        }
    }
}
