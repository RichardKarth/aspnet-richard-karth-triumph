using Application.Common.Results;
using Application.Members.Inputs;
using Domain.Abstractions.Repositories.Members;
using Domain.Aggregates.Members;

public class UpdateMemberMembershipService(IMemberRepository memberRepository) : IUpdateMemberMembershipService
{
    public async Task<Result<Member>> ExecuteAsync(UpdateMemberMembershipInput input, CancellationToken ct = default)
    {
        var member = await memberRepository.GetMemberByUserIdAsync(input.UserId, ct);

        if (member is null)
            return Result<Member>.NotFound("Member not found");

        member.ChangeMembership(input.MembershipId);

        var updated = await memberRepository.UpdateAsync(member, ct);

        return updated
            ? Result<Member>.Ok(member)
            : Result<Member>.Error("Membership was not updated");
    }
}
