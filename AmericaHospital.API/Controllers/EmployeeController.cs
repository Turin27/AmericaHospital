using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AmericaHospital.API.Models;
using AmericaHospital.Models.Entities;
using AmericaHospital.Services.Business;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmericaHospital.API.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<EmployeeDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            
            if (employees is null) return NotFound();

            var employeeListDto = _mapper.Map<IList<EmployeeDto>>(employees);

            return Ok(employeeListDto);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

            if (employee is null) return NotFound();

            var employeeByIdDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeByIdDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] UpsertEmployeeDto upsertEmployeeDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var employee = _mapper.Map<Employee>(upsertEmployeeDto);

            var addEmployee = await _employeeService.AddEmployeeAsync(employee);

            if (addEmployee is null) return NotFound();

            var addEmployeeDto = _mapper.Map<UpsertEmployeeDto>(addEmployee);

            return StatusCode((int)HttpStatusCode.Created, addEmployeeDto);
        }
    }
}
