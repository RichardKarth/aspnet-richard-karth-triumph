using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.WebApp.Models.Account;

public class MyAccountViewModel
{
    public MyProfileForm AboutMeForm { get; set; } = null!;
    public string Email { get; set; } = string.Empty;

    public string? SelectedMembershipId { get; set; }
    public List<SelectListItem> MembershipOptions { get; set; } = [];
    public string? SelectedMembershipTitle { get; set; }

}