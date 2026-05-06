
using Infrastructure.Persistance.Contexts;
using Infrastructure.Persistance.Entities.Memberships;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistance;

public static class PersistanceDatabaseInitializer
{
    public static async Task InitializeAsync(
        IServiceProvider sp,
        IHostEnvironment env,
        CancellationToken ct = default)
    {
        using var scope = sp.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        await context.Database.EnsureCreatedAsync(ct);

        // CREATE MEMBERSHIPS IF DATABASE IS EMPTY

        if (!context.Memberships.Any())
        {
            context.Memberships.AddRange(

                new MembershipEntity
                {
                    Id = "standard",
                    Title = "With the Standard Membership, get access\r\nto our full range of gym facilities.",
                    Description = "Basic gym access",
                    Price = 199,
                    MonthlyClasses = 8
                },

                new MembershipEntity
                {
                    Id = "premium",
                    Title = "With the Premium Membership, get access\r\nto our full range of gym facilities.",
                    Description = "Full access + extra classes",
                    Price = 399,
                    MonthlyClasses = 20
                }

            );

            await context.SaveChangesAsync(ct);
        }

        // UPDATE EXISTING MEMBERSHIPS

        var standard = context.Memberships
            .FirstOrDefault(x => x.Id == "standard");

        if (standard != null)
        {
            standard.Title = "Standard Membership";
            standard.Description = "With the Standard Membership, get access\r\nto our full range of gym facilities.";
            standard.Price = 199;
            standard.MonthlyClasses = 8;
        }

        var premium = context.Memberships
            .FirstOrDefault(x => x.Id == "premium");

        if (premium != null)
        {
            premium.Title = "Premium Membership";
            premium.Description = "With the Premium Membership, get access\r\nto our full range of gym facilities.";
            premium.Price = 399;
            premium.MonthlyClasses = 20;
        }

        await context.SaveChangesAsync(ct);
    }
}