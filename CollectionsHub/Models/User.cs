using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CollectionsHub.Models
{
    public class User : IdentityUser<Guid>
    {
        //[Required(ErrorMessage = "Please provide a valid password")]
        //[DataType(DataType.Password)]
        //[Display(Prompt = "Must have at least 1 character")]
        //public required string Password { get; set; }

        //[Required(ErrorMessage = "Please provide a valid email address")]
        //[EmailAddress(ErrorMessage = "Please provide a valid email address")]
        //[DataType(DataType.EmailAddress)]
        //[Display(Prompt = "johndoe@xxxxx.xxx")]
        //public required string EmailAddress { get; set; }


        public DateTime RegDate { get; set; } = DateTime.UtcNow;

        // using event to fire handler
        public DateTime? LastLoginDate { get; set; }
    }
}
