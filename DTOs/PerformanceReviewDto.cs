using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class PerformanceReviewDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public string EmployeeId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Employee full name is required.")]
        [StringLength(100, ErrorMessage = "Employee full name cannot exceed 100 characters.")]
        public string EmployeeFullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Review Date is required.")]
        public DateTime ReviewDate { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Review comments are required.")]
        [StringLength(500, ErrorMessage = "Review comments cannot exceed 500 characters.")]
        public string ReviewComments { get; set; } = string.Empty;

        [Required(ErrorMessage = "Manager ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Manager ID must be a positive number.")]
        public int ManagerId { get; set; } // Changed from string to int

        [Required(ErrorMessage = "Manager full name is required.")]
        [StringLength(100, ErrorMessage = "Manager full name cannot exceed 100 characters.")]
        public string ManagerFullName { get; set; } = string.Empty;
    }
}
