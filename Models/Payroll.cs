using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Payroll
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; } = null!;

        [Required]
        public decimal BasicSalary { get; set; }

        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }

        [Required]
        public decimal TotalSalary { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }
    }
}
