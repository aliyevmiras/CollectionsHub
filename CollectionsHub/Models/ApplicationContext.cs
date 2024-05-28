using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionsHub.Models
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();

            // ignore unnecessary columns for user inherited from IdentityUser class
            //modelBuilder.Entity<User>().Ignore(x => x.UserName);
            //modelBuilder.Entity<User>().Ignore(x => x.NormalizedUserName);
            //modelBuilder.Entity<User>().Ignore(x => x.SecurityStamp);
            //modelBuilder.Entity<User>().Ignore(x => x.TwoFactorEnabled);
            //modelBuilder.Entity<User>().Ignore(x => x.LockoutEnabled);
            //modelBuilder.Entity<User>().Ignore(x => x.LockoutEnd);
            //modelBuilder.Entity<User>().Ignore(x => x.ConcurrencyStamp);
            //modelBuilder.Entity<User>().Ignore(x => x.AccessFailedCount);
            //modelBuilder.Entity<User>().Ignore(x => x.EmailConfirmed);
            ////modelBuilder.Entity<User>().Ignore(x => x.NormalizedEmail);
            ////modelBuilder.Entity<User>().Ignore(x => x.PasswordHash);
            //modelBuilder.Entity<User>().Ignore(x => x.PhoneNumber);
            //modelBuilder.Entity<User>().Ignore(x => x.PhoneNumberConfirmed);

            //modelBuilder.Entity<User>().Ignore(x => x.Email);
        }

        public async Task<Collection> AddCollection(Collection newCollection)
        {
            Collections.Add(newCollection);
            await SaveChangesAsync();
            return newCollection;
        }
    }
}
