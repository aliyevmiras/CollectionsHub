using CollectionsHub.Models;
using Microsoft.AspNetCore.Identity;

namespace CollectionsHub.Infrastructure
{
    public static class UserManagerExtensions
    {
        public async static Task<IdentityResult> UpdateLastLoginDate(this UserManager<User> userManager, User user)
        {
            user.LastLoginDate = DateTime.UtcNow;
            return await userManager.UpdateAsync(user);
        }
    }
}
