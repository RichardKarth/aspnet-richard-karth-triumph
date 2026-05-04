

namespace Application.Members.Inputs;

public record UpdateMemberProfileInput
(
    string UserId,
    string FirstName,
    string LastName,
    string Email,
    string? PhoneNumber,
    string? ProfileImageUrl
);

