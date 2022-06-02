using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AmericaHospital.DAL
{
    public class AmericaHospitalDbContextFactory : IDesignTimeDbContextFactory<AmericaHospitalDbContext>
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public AmericaHospitalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AmericaHospitalDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Defaultconnection"),
                options =>
                {
                    options.EnableRetryOnFailure();
                });
            return new AmericaHospitalDbContext(optionsBuilder.Options);
        }
    }
}
