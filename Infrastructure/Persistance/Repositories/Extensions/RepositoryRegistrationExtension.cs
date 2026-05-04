

using Domain.Abstractions.Repositories;
using Domain.Abstractions.Repositories.Members;
using Infrastructure.Persistance.Repositories.Members;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistance.Repositories.Extensions
{
    public static class RepositoryRegistrationExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            return services;
        }
    }
}
