using System.Collections.Generic;
using EmployeesApp.Core.DTOs;

namespace EmployeesApp.Core.Interfaces.Factories
{
    public interface IEmployeeFactory
    {
        EmployeeDto Create(EmployeeResponseDto employee);
        IEnumerable<EmployeeDto> Create(IEnumerable<EmployeeResponseDto> employees);
    }
}