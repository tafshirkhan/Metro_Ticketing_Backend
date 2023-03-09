using Metro.Ticketing.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metro.Ticketing.IoC
{
    public static class DbConfig
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MetroTicketingDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("MetroTicketingDbContext"))
                );

            return services;
        }

    }
}