

using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistance.Entities;

public class ApplicationUserEntity : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ProfileImageUrl { get; set; }
}
