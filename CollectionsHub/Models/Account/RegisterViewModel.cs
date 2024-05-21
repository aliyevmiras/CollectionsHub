using System.ComponentModel.DataAnnotations;

namespace CollectionsHub.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please provide a valid username")]
        [Display(Prompt = "JohnDoe")]
        public required string UserName { get; set; }


        [Required(ErrorMessage = "Please provide a valid email address")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "johndoe@xxxxx.xxx")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Please provide a valid password")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Must have at least 1 character")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Please provide a valid password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Confirm password")]
        public required string ConfirmPassword { get; set; }
    }
}
