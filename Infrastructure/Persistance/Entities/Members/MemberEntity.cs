using Infrastructure.Identity;
using Infrastructure.Persistance.Entities.Memberships;

namespace Infrastructure.Persistance.Entities.Members;

public class MemberEntity
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;

    public string? MembershipId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfileImageUrl { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }

    public ApplicationUser User { get; set; } = null!;
    public MembershipEntity? Membership { get; set; }
}