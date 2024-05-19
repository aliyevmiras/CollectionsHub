using System.ComponentModel.DataAnnotations;

namespace CollectionsHub.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please provide a valid email address")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "johndoe@xxxxx.xxx")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Please provide a valid password")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Must have at least 1 character")]
        public required string Password { get; set; }
    }
}
