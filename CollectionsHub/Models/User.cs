using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CollectionsHub.Models
{
    public class User : IdentityUser<Guid>
    {
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        // using event to fire handler
        public DateTime? LastLoginDate { get; set; }
    }
}
