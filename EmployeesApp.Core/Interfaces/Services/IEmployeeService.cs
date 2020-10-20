using System.Collections.Generic;
using EmployeesApp.Core.DTOs;

namespace EmployeesApp.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployeeById(int id);
        IEnumerable<EmployeeDto> GetEmployees();
    }
}