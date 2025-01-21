using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true; // Active status of the department
        public ICollection<Employee> Employees { get; set; } = new List<Employee>(); // Navigation property
    }
}
