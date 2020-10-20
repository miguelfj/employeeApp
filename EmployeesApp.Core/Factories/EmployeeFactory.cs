using EmployeesApp.Core.DTOs;
using EmployeesApp.Core.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace EmployeesApp.Core.Factories
{
    public sealed class EmployeeFactory : IEmployeeFactory
    {
        public IEnumerable<EmployeeDto> Create(IEnumerable<EmployeeResponseDto> employees)
        {
            List<EmployeeDto> results = new List<EmployeeDto>();
            foreach (var employee in employees)
            {
                results.Add(CreateEmployee(employee));
            }

            return results;
        }

        public EmployeeDto Create(EmployeeResponseDto employee)
        {
            if(employee != null)
            {
                return CreateEmployee(employee);
            }
            else
            {
                return null;
            }            
        }

        private EmployeeDto CreateEmployee(EmployeeResponseDto employee)
        {
            switch (employee.ContractTypeName)
            {
                case "MonthlySalaryEmployee":
                    return GetMonthlyPaidEmployee(employee);
                case "HourlySalaryEmployee":
                    return GetHourlyPaidEmployee(employee);
                default:
                    throw new NotImplementedException();
            }            
        }

        private EmployeeDto GetHourlyPaidEmployee(EmployeeResponseDto employee)
        {
            return new HourlyPaidEmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                RoleId = employee.RoleId,
                RoleName = employee.RoleName,
                RoleDescription = employee.RoleDescription,
                HourlySalary = employee.HourlySalary
            };
        }

        private EmployeeDto GetMonthlyPaidEmployee(EmployeeResponseDto employee)
        {
            return new MonthlyPaidEmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                RoleId = employee.RoleId,
                RoleName = employee.RoleName,
                RoleDescription = employee.RoleDescription,
                MonthlySalary = employee.MonthlySalary
            };
        }


    }
}
