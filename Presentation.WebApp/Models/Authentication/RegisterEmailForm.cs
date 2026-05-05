using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models.Authentication
{
    public class RegisterEmailForm
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address", Prompt = "Enter your email address")]
        public string Email { get; set; } = null!;
    }
}