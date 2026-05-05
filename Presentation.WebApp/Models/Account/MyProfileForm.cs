using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models.Account;

public class MyProfileForm
{
    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "First Name", Prompt = "Enter First Name")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last Name", Prompt = "Enter Last Name")]
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number", Prompt = "Enter Phone Number")]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Url]
    [Display(Name = "Profile Image", Prompt = "Upload Profile Image")]
    public string? ProfileImageUrl { get; set; }
}
