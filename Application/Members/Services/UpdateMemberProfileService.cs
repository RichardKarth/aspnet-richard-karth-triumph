using Application.Common.Results;
using Application.Members.Abstractions;
using Application.Members.Inputs;
using Domain.Abstractions.Repositories.Members;
using Domain.Aggregates.Members;

namespace Application.Members.Services;

public class UpdateMemberProfileService(IMemberRepository memberRepository) : IUpdateMemberProfileService
{
    public async Task<Result<Member>> ExecuteAsync(UpdateMemberProfileInput input, CancellationToken ct = default)
    {
        try
        {
            if (input is null)
            {
                throw new ArgumentException("Input must be provided");
            }
            var member = await memberRepository.GetMemberByUserIdAsync(input.UserId, ct);

            if (member is null)
            {
                return Result<Member>.NotFound($"Member with user id {input.UserId} was not found");
            }
            member.Updateinformation(input.FirstName, input.LastName, input.Email, input.PhoneNumber, input.ProfileImageUrl);
            var result = await memberRepository.UpdateAsync(member, ct);

            return !result ? Result<Member>.Error($"member with user is {member.UserId} was not updated") : Result<Member>.Ok(member);
        }
        catch (Exception ex)
        {
            return Result<Member>.Error(ex.Message);
        }
    }
}



