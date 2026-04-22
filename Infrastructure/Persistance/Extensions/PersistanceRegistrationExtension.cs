using Infrastructure.Persistance.Contexts.Extensions;
using Infrastructure.Persistance.Repositories.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistance.Extensions
{
    public static class PersistanceRegistrationExtension
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddDbContexts(configuration, env);
            services.AddRepositories(configuration, env);
            return services;
        }
    }
}
