using Application.Abstractions.Identity;
using Infrastructure.Identity;
using Infrastructure.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Identity;

public static class IdentityRegistrationExtension
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;

            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
        })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/MyAccount/Index";
            options.AccessDeniedPath = "/MyAccount/AccessDenied";
            options.Cookie.Name = "CoreFitness.Auth";
        });
        services.AddScoped<IIdentityService, IdentityService>();
        return services;
    }
}
