using AutoFixture;
using EmployeesApp.Core.DTOs;
using EmployeesApp.Core.Interfaces.Repositories;
using EmployeesApp.Core.Services;
using Moq;
using NUnit.Framework;

namespace EmployeeApp.Tests.Core.Services
{
    [TestFixture]
    public class EmployeeServiceTests
    {        
        [Test]
        public void Can_Get_Employee_With_Calculated_Salary()
        {
            var fixture = new Fixture();
            var employee = fixture.Create<MonthlyPaidEmployeeDto>();
            employee.MonthlySalary = 3500;

            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(employee);

            var service = new EmployeeService(repositoryMock.Object);
            EmployeeDto result = service.GetEmployeeById(2);

            Assert.AreEqual(3500 * 12, result.Salary);
        }
    }
}
