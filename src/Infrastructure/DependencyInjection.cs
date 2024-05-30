using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GuestifyDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Database")));

            services.AddStackExchangeRedisCache(options =>
                options.Configuration = configuration.GetConnectionString("Cache"));

            return services;
        }
    }
}
