using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty; // For displaying department name

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
