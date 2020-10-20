using EmployeesApp.Core.DTOs;
using System.Collections.Generic;

namespace EmployeesApp.Core.Interfaces.HttpRequests
{
    public interface IGetEmployeesRequest
    {
        IEnumerable<EmployeeResponseDto> Execute();
    }
}
