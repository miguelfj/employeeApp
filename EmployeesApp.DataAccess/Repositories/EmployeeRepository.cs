
using EmployeesApp.Core.DTOs;
using EmployeesApp.Core.Interfaces.Factories;
using EmployeesApp.Core.Interfaces.HttpRequests;
using EmployeesApp.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesApp.DataAccess.Repositories
{
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        private IGetEmployeesRequest _getEmployeesRequest;
        private IEmployeeFactory _employeeFactory;

        public EmployeeRepository(IGetEmployeesRequest getEmployeesRequest, IEmployeeFactory employeeFactory)
        {
            _getEmployeesRequest = getEmployeesRequest;
            _employeeFactory = employeeFactory;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            IEnumerable<EmployeeResponseDto> results = _getEmployeesRequest.Execute();

            return _employeeFactory.Create(results);
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            IEnumerable<EmployeeResponseDto> results = _getEmployeesRequest.Execute();
            EmployeeResponseDto employee = results.Where(x => x.Id == id).SingleOrDefault();

            return _employeeFactory.Create(employee);
        }
    }
}
