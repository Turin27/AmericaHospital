using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmericaHospital.DAL;
using AmericaHospital.Services.Business;
using Microsoft.Extensions.DependencyInjection;

namespace AmericaHospital.Services
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.ConfigureDalDependencies();

            return services;
        }

        public static void ConfigureServiceDbContext(this IServiceCollection services, string connectionString)
        {
            services.ConfigureDalDbContexts(connectionString, asNoTracking:false);
        }
    }
}
