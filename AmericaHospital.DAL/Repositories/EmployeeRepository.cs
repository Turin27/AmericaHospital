using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmericaHospital.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmericaHospital.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AmericaHospitalDbContext _dbContext;

        public EmployeeRepository(AmericaHospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _dbContext.Employees.ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);

            return employee;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();

            return employee;
        }
    }
}
