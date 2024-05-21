using System.ComponentModel.DataAnnotations;

namespace CollectionsHub.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public required string UserName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Please provide a valid password")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Please provide a valid password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
