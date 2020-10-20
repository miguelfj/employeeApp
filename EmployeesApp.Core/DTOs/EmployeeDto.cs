namespace EmployeesApp.Core.DTOs
{
    public abstract class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal Salary { get; protected set; }

        public abstract void CalculateSalary();
    }
}
