using Infrastructure.Persistance.Contexts;
using Infrastructure.Persistance.Entities.Memberships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistance;

public static class PersistanceDatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider sp, IHostEnvironment env, CancellationToken ct = default)
    {
        using var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        
        
         await context.Database.EnsureCreatedAsync(ct);
        
        

        if (!context.Memberships.Any())
        {
            context.Memberships.AddRange(
                new MembershipEntity
                {
                    Id = "standard",
                    Title = "Standard Membership",
                    Description = "Basic gym access",
                    Price = 199,
                    MonthlyClasses = 8
                },
                new MembershipEntity
                {
                    Id = "premium",
                    Title = "Premium Membership",
                    Description = "Full access + extra classes",
                    Price = 399,
                    MonthlyClasses = 20
                }
            );

            await context.SaveChangesAsync(ct);
        }
    }
}