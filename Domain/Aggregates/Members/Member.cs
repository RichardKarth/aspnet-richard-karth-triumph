

using System.Linq.Expressions;

namespace Domain.Aggregates.Members;

public class Member
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? MembershipId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }

    private Member()
    {

    }
    private Member(string id, string userId, DateTimeOffset createdAt)
    {
        Id = id;
        UserId = userId;
        CreatedAt = createdAt;
    }
    public static Member Create(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException("Application User is is required.");
        }
        var member = new Member(
            Guid.NewGuid().ToString(),
            userId,
            DateTimeOffset.UtcNow
            );
        return member;
    }
    public static Member Create(string id, string userId, string? firstName, string? lastName, string? phoneNumber, string? profileImageUrl, string? membershipId, DateTimeOffset createdAt, DateTimeOffset modifiedAt)
    {
        var member = new Member(id, userId, createdAt)
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            ProfileImageUrl = profileImageUrl,
            MembershipId = membershipId,
            ModifiedAt = modifiedAt
        };
        return member;
    }

    public void Updateinformation(string? firstName, string? lastName, string? email, string? phoneNumber, string? profileImageUrl)
    {
        if(string.IsNullOrWhiteSpace(firstName))
            {
            throw new ArgumentException("First name is required.");
        }
        if(string.IsNullOrWhiteSpace(lastName))
            {
            throw new ArgumentException("Last name is required.");
        }
        FirstName = firstName.Trim();
        LastName = lastName.Trim();

        Email = email;
        PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber.Trim();
        ProfileImageUrl = string.IsNullOrWhiteSpace(profileImageUrl) ? null : profileImageUrl.Trim();
        ModifiedAt = DateTimeOffset.UtcNow;
    }

    public void ChangeMembership(string? membershipId)
    {
        MembershipId = string.IsNullOrWhiteSpace(membershipId) ? null : membershipId;
        ModifiedAt = DateTimeOffset.UtcNow;
    }

    public static Member Rehydrate(string id, string userId, string? firstName, string? lastName, string? email, string? phoneNumber, string? profileImageUrl, string? membershipId, DateTimeOffset createdAt, DateTimeOffset modifiedAt)
    {
        var member = new Member(id, userId, createdAt)
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            ProfileImageUrl = profileImageUrl,
            MembershipId = membershipId,
            ModifiedAt = modifiedAt

        };
        return member;
    }


}
