namespace EmployeesApp.Core.DTOs
{
    public class HourlyPaidEmployeeDto : EmployeeDto
    {
        public decimal HourlySalary { get; set; }

        public override void CalculateSalary()
        {
            Salary = 120 * HourlySalary * 12;
        }
    }
}
