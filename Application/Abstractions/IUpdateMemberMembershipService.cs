using Application.Common.Results;
using Application.Members.Inputs;
using Domain.Aggregates.Members;

public interface IUpdateMemberMembershipService
{
    Task<Result<Member>> ExecuteAsync(UpdateMemberMembershipInput input, CancellationToken ct = default);
}