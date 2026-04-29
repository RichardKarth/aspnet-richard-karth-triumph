namespace Presentation.WebApp.Models;

public class SignInViewModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; }
}
