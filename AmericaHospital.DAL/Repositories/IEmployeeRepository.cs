using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmericaHospital.Models.Entities;

namespace AmericaHospital.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int employeeId);

        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}
