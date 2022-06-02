using AmericaHospital.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmericaHospital.DAL
{
    public class AmericaHospitalDbContext : DbContext
    {
        public AmericaHospitalDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasData(new Employee { Id = 1, FirstName = "Rodrigo", LastName = "Fuentes" });
            builder.Entity<Employee>().HasData(new Employee { Id = 2, FirstName = "Erwin", LastName = "Fuentes" });
            builder.Entity<Employee>().HasData(new Employee { Id = 3, FirstName = "Pedro", LastName = "Fuentes" });
        }
    }
}
