using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models.Authentication
{
    public class SignInForm
    {
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email Address", Prompt = "Enter your email address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter your password")]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}