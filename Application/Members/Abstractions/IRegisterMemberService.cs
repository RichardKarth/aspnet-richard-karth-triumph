using Application.Common.Results;
using Application.Members.Inputs;

namespace Application.Members.Abstractions;

public interface IRegisterMemberService
{
    Task<Result<string?>> ExecuteAsync(RegisterMemberAccountInput input, CancellationToken ct = default);
}