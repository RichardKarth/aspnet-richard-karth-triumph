using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistance.Contexts;

public static class ContextRegistrationExtension
{
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
        if (env.IsDevelopment())
        {
            Console.WriteLine("Development Environment");
            services.AddSingleton<SqliteConnection>(_ =>
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                return connection;
            });

            services.AddDbContext<DataContext>((serviceProvider, options) =>
            {
                var connection = serviceProvider.GetRequiredService<SqliteConnection>();
                options.UseSqlite(connection);
            });
        }
        else
        {
            Console.WriteLine("Production Environment");

            services.AddDbContext<DataContext>((sp, options) =>
            {
                var connection = configuration.GetConnectionString("ProductionDatabaseUrl")
                   ?? throw new ArgumentException ("Production Database Url Not Provided");
                options.UseSqlServer(connection);
            });


        }

            return services;
        }
}
