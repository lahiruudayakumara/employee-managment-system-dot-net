using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class PayrollDto
    {
        [Required(ErrorMessage = "Employee Id is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bonuses cannot be negative.")]
        public decimal Bonuses { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Deductions cannot be negative.")]
        public decimal Deductions { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Tax cannot be negative.")]
        public decimal Tax { get; set; }

        [Required(ErrorMessage = "Net Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Net Salary must be a positive value.")]
        public decimal NetSalary { get; set; }

        [Required(ErrorMessage = "Pay Date is required.")]
        public DateTime PayDate { get; set; }

        [Required(ErrorMessage = "Pay Slip is required.")]
        public string PaySlip { get; set; } = string.Empty;
    }
}
