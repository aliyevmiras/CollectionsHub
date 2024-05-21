using CollectionsHub.Models;
using CollectionsHub.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CollectionsHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext")));
            builder.Services.AddIdentity<User, IdentityRole<Guid>>()
                            .AddRoles<IdentityRole<Guid>>()
                            .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
                            .AddEntityFrameworkStores<ApplicationContext>();

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            SeedData.EnsurePopulated(app.Services);

            app.Run();
        }
    }
}
