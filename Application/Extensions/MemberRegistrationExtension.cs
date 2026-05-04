

using Application.Members.Abstractions;
using Application.Members.Services;
using Application.Memberships;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Extensions;

public static class MemberRegistrationExtension
{
    public static IServiceCollection AddMemberServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterMemberService, RegisterMemberService>();
        services.AddScoped<IGetMemberProfileService, GetMemberProfileService>();
        services.AddScoped<ISignInMemberService, SignInMemberService>();
        services.AddScoped<IUpdateMemberProfileService, UpdateMemberProfileService>();

        return services;
    }
}
