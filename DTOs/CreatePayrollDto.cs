using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class CreatePayrollDto
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        public string EmployeeId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bonuses must be a positive value.")]
        public decimal Bonuses { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Deductions must be a positive value.")]
        public decimal Deductions { get; set; }

        [Required(ErrorMessage = "Tax amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Tax must be a positive value.")]
        public decimal Tax { get; set; }
    }
}
