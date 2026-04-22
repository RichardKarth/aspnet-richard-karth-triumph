

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistance.Repositories.Extensions
{
    public static class RepositoryRegistrationEextension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            return services;
        }
    }
}
