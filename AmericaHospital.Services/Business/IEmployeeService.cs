using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmericaHospital.Models.Entities;

namespace AmericaHospital.Services.Business
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int employeeId);

        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}
