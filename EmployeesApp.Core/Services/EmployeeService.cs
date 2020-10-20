using EmployeesApp.Core.DTOs;
using EmployeesApp.Core.Interfaces.Repositories;
using EmployeesApp.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesApp.Core.Services
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            List<EmployeeDto> results = _repository.GetEmployees().ToList();
            results.ForEach(employee => employee.CalculateSalary());

            return results;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            EmployeeDto result = _repository.GetEmployeeById(id);
            result?.CalculateSalary();

            return result;
        }
    }
}
