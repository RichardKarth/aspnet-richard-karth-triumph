
using Application.Common.Results;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Application.Abstractions.Identity;

public interface IIdentityService
{
    Task<Result<string?>> CreateUserAsync(string email, string password, CancellationToken ct = default);
    Task<Result<string?>> PasswordSignInAsync(string email, string password, bool rememberMe, CancellationToken ct = default);
    Task SignOutAsync(CancellationToken ct = default);
}
