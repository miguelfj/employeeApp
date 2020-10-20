using EmployeesApp.Core.DTOs;
using System.Collections.Generic;

namespace EmployeesApp.Core.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeDto GetEmployeeById(int id);
        IEnumerable<EmployeeDto> GetEmployees();
    }
}