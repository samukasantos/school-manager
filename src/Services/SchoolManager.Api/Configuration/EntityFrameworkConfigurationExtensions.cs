using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManager.Api.Data.Context;
using SchoolManager.Api.Settings;
using System;

namespace SchoolManager.Api.Configuration
{
    public static class EntityFrameworkConfigurationExtensions
    {
        public static void AddEntityFrameworkConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolManagerDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("SchoolManagerDatabase"))
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors()
           );
        }
    }
}
