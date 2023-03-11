using Metro.Ticketing.BL.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.IoC
{
    public static class BusinessConfig
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UserBusiness>();
            services.AddScoped<TrainBusiness>();
            services.AddScoped<SeatBusiness>();
            services.AddScoped<PassengerBusiness>();
            return services;
        }
    }
}
