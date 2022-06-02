using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmericaHospital.DAL.Repositories;
using AmericaHospital.Models.Entities;

namespace AmericaHospital.Services.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IList<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            return employee;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var addEmployee = await _employeeRepository.AddEmployeeAsync(employee);

            return addEmployee;
        }
    }
}
