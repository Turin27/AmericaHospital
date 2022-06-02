using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmericaHospital.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AmericaHospital.DAL
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureDalDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }

        public static void ConfigureDalDbContexts(this IServiceCollection services, string connectionString, bool asNoTracking)
        {
            services.AddDbContextPool<AmericaHospitalDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                });
                optionsBuilder.UseQueryTrackingBehavior(asNoTracking
                    ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);
            });
        }
    }
}
