using EmployeesApp.Core.DTOs;
using EmployeesApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            IEnumerable<EmployeeDto> employees = _employeeService.GetEmployees();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            EmployeeDto employee = _employeeService.GetEmployeeById(id);

            if(employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }

    }
}