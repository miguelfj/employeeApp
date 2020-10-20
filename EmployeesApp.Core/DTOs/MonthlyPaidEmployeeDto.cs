namespace EmployeesApp.Core.DTOs
{
    public class MonthlyPaidEmployeeDto : EmployeeDto
    {
        public decimal MonthlySalary { get; set; }

        public override void CalculateSalary()
        {
            Salary = MonthlySalary * 12;
        }
    }
}
